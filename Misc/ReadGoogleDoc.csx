// Question - Read a published Google Doc containing Unicode character grid positions and print the hidden message
// #misc #http #google-docs #grid

#r "nuget: HtmlAgilityPack, 1.11.61"

using System.Net.Http;
using System.Text.RegularExpressions;
using System.Net;
using HtmlAgilityPack;

record GridCell(int X, char Character, int Y);

// --- Parsing (Option 1): Using Regex ---
List<GridCell> ParseWithRegex(string html)
{
    var results = new List<GridCell>();
    var rows = Regex.Matches(html, @"<tr[^>]*>(.*?)</tr>", RegexOptions.Singleline);

    foreach (Match row in rows)
    {
        var cells = Regex.Matches(row.Groups[1].Value, @"<td[^>]*>(.*?)</td>", RegexOptions.Singleline);
        if (cells.Count < 3) continue;

        string xStr = StripHtml(cells[0].Groups[1].Value);
        string character = StripHtml(cells[1].Groups[1].Value);
        string yStr = StripHtml(cells[2].Groups[1].Value);

        if (!int.TryParse(xStr, out int x) || !int.TryParse(yStr, out int y)) continue;
        results.Add(new GridCell(x, character[0], y));
    }
    return results;
}

string StripHtml(string s) => WebUtility.HtmlDecode(Regex.Replace(s, @"<[^>]+>", "").Trim());

// --- Parsing (Option 2): Using HtmlAgilityPack ---
// 1. LoadHtml() parses the raw HTML string into a navigable DOM tree
// 2. SelectNodes("//table//tr") uses XPath to find all <tr> rows inside any <table>
// 3. For each row, SelectNodes("td") gets the table cells as node objects
// 4. InnerText on each cell gives us the decoded text content without any nested tags
// 5. We extract x, character, y from the 3 cells and build our grid data
List<GridCell> ParseWithDom(string html)
{
    var results = new List<GridCell>();
    var doc = new HtmlDocument();
    doc.LoadHtml(html);

    var rows = doc.DocumentNode.SelectNodes("//table//tr");
    if (rows == null) return results;

    foreach (var row in rows)
    {
        var cells = row.SelectNodes("td");
        if (cells == null || cells.Count < 3) continue;

        string xStr = WebUtility.HtmlDecode(cells[0].InnerText.Trim());
        string character = WebUtility.HtmlDecode(cells[1].InnerText.Trim());
        string yStr = WebUtility.HtmlDecode(cells[2].InnerText.Trim());

        if (!int.TryParse(xStr, out int x) || !int.TryParse(yStr, out int y)) continue;
        results.Add(new GridCell(x, character[0], y));
    }
    return results;
}

// --- Grid rendering ---
void PrintGrid(List<GridCell> data)
{
    int maxX = 0, maxY = 0;
    var grid = new Dictionary<(int x, int y), char>();

    foreach (var cell in data)
    {
        grid[(cell.X, cell.Y)] = cell.Character;
        maxX = Math.Max(maxX, cell.X);
        maxY = Math.Max(maxY, cell.Y);
    }

    for (int y = maxY; y >= 0; y--)
    {
        var line = new char[maxX + 1];
        for (int x = 0; x <= maxX; x++)
            line[x] = grid.GetValueOrDefault((x, y), ' ');
        Console.WriteLine(new string(line));
    }
}

// --- Main ---
void PrintUnicodeGrid(string url, bool useDom = false)
{
    var client = new HttpClient();
    var html = client.GetStringAsync(url).Result;

    var data = useDom ? ParseWithDom(html) : ParseWithRegex(html);
    PrintGrid(data);
}

// var url = "https://docs.google.com/document/d/e/2PACX-1vTMOmshQe8YvaRXi6gEPKKlsC6UpFJSMAk4mQjLm_u1gmHdVVTaeh7nBNFBRlui0sTZ-snGwZM4DBCT/pub";
var url = "https://docs.google.com/document/d/e/2PACX-1vSvM5gDlNvt7npYHhp_XfsJvuntUhq184By5xO_pA4b_gCWeXb6dM6ZxwN8rE6S4ghUsCj2VKR21oEP/pub";

PrintUnicodeGrid(url, useDom: true);
