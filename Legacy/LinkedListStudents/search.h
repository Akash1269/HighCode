#ifndef SEARCH_H
#define SEARCH_H
#include "inputOutput.h"
#include "main.h"
int compareKey(key k1, key k2);
find searchKey(node *head, node **prev, node **current, key k);
#endif
