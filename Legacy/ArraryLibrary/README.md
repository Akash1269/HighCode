# Array DS Library — Library Management System

A library records management system using a fixed-size array of structs in C. Written as a DSPD college assignment.

## Data Types

| Type | Description |
|---|---|
| `struct library` | Record: `name`, `author`, `year`, `num` (copies) |
| Global `lib[SIZE]` | Array of 5 library records |

## Functions

| Function | Description |
|---|---|
| `reset` | Clear all records to empty state |
| `scan` | Read `n` records from stdin |
| `print` | Display all non-empty records |
| `sort` | Bubble sort by author, then by name |
| `isfull` / `isempty` | Check if array is full or empty |
| `search` | Find record by name + author, returns index or -1 |
| `insert` | Insert or update a record |
| `del` | Delete a record by name + author |
| `active` | Count non-empty records |
| `topauthor` | Find author with most copies for a given book |
| `list_unique` | Remove duplicate entries (keeps newer year) |
| `list_union` | Union of current list with list2.txt |
| `intersection` | Intersection of current list with list2.txt |
| `set_difference` | Difference: list1 - list2 |
| `symmetric_difference` | Symmetric difference of both lists |

## Data Files

- `list1.txt` — Primary library records (auto-saved after each operation)
- `list2.txt` — Secondary list for set operations

## Known Issues

| # | Issue | Severity |
|---|---|---|
| 1 | `sort` compares `strcmp() == 1` instead of `> 0` — incorrect for many compilers | Bug |
| 2 | `insert` calls `search(lib, ...)` using global instead of parameter `l` | Bug |
| 3 | `list_union` writes `SIZE*2` entries into `listout[SIZE]` — buffer overflow | Bug |
| 4 | File write uses original `n` instead of `active(lib)` after inserts/deletes | Bug |
| 5 | `scanf("%s")` has no width limit — buffer overflow risk | Security |
| 6 | No `fopen` NULL checks — crashes if files missing | Medium |
| 7 | `main()` missing `int` return type | Deprecated |

## Notes

- Only supports single-word strings (no spaces in names/authors)
- Fixed capacity of 5 records (`SIZE`)
- Persists data to `list1.txt` after every operation
