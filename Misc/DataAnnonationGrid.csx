#r "nuget: HtmlAgilityPack, 1.11.61"

using System.Net.Http;
using System.Text.RegularExpressions;
using System.Net;
using HtmlAgilityPack;

record GridCell(int X, char Character, int Y);

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

        if (cells != null && cells.Count >= 3)
        {
            string xStr = WebUtility.HtmlDecode(cells[0].InnerText.Trim());
            string character = WebUtility.HtmlDecode(cells[1].InnerText.Trim());
            string yStr = WebUtility.HtmlDecode(cells[2].InnerText.Trim());

            if (int.TryParse(xStr, out int x) && int.TryParse(yStr, out int y))
            {
                results.Add(new GridCell(x, character[0], y));
            }
        }
    }
    return results;
}

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
        {
            line[x] = grid.GetValueOrDefault((x, y), ' ');
        }
        
        Console.WriteLine(new string(line));
    }
}

void PrintUnicodeGrid(string url)
{
    var client = new HttpClient();
    var html = client.GetStringAsync(url).Result;

    var data = ParseWithDom(html);
    
    PrintGrid(data);
}

var url = "https://docs.google.com/document/d/e/2PACX-1vSvM5gDlNvt7npYHhp_XfsJvuntUhq184By5xO_pA4b_gCWeXb6dM6ZxwN8rE6S4ghUsCj2VKR21oEP/pub";

PrintUnicodeGrid(url);