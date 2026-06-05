# Student Database — Linked List (Legacy C Project)

A student records management system built using a singly linked list in C. Originally written as a DSPD-II (Data Structures) course project.

## Data Types

| Type | Description |
|---|---|
| `key` | Composite key: `roll` (int) + `sub_code` (char[]) |
| `student` | Record: `key`, `name`, `marks` |
| `node` | Linked list node containing a `student` and `next` pointer |
| `status` | Enum: `SUCCESS`, `FAILURE` |
| `find` | Enum: `FOUND`, `NOTFOUND` |

## Modules & Functions

### main.c / main.h
- `printMenu()` — Display full menu
- `printMenuShort()` — Display short menu
- `freeList(node *ptr)` — Free all nodes in the list

### inputOutput.c / inputOutput.h
- `createNode(student s)` — Allocate and return a new node
- `scanData()` — Read student data from user input
- `printData(student s)` — Print a single student record
- `printList(node *ptr)` — Print all records in the list
- `printToFile(node *head, char file_name[])` — Write list to file
- `createList()` — Create list (prompts for source: file or input)
- `createListFromFile(char file_name[])` — Load list from a text file
- `createListFromInput(int n)` — Build list from `n` user entries

### insertDelete.c / insertDelete.h
- `insertNode(node *head, student s)` — Insert or update a student record (sorted by key)
- `deleteNode(node **hpptr, key k)` — Delete node matching the given key

### search.c / search.h
- `compareKey(key k1, key k2)` — Compare two keys (returns 0 if equal)
- `searchKey(node *head, node **prev, node **current, key k)` — Search for a key, returns `FOUND`/`NOTFOUND` with prev/current pointers

### other.c / other.h
- `getMaxMarks(char sub_code[], node *head)` — Get node with highest marks in a subject
- `getNumRecords(node *head)` — Count total records
- `isEmpty(node *head)` — Check if list is empty
- `uniqueList(node *head)` — Remove duplicate entries

### setOperations.c / setOperations.h
- `listIntersection(node *list1, node *list2)` — Return common records
- `listUnion(node *list1, node *list2)` — Return merged unique records
- `listSymmetricDifference(node *list1, node *list2)` — Records in either but not both
- `listDifference(node *list1, node *list2)` — Records in list1 but not list2

### password.c / password.h
- `passwordCheck()` — Simple login check (3 attempts max)

## Data Files

- `list1.txt` / `list2.txt` — Sample student record files for testing set operations
