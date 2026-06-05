#ifndef SET_OPERATIONS_H
#define SET_OPERATIONS_H
#include "inputOutput.h"
#include "main.h"
#include "search.h"
node *listIntersection(node *list1, node *list2);
node *listUnion(node *list1, node *list2);
node *listSymmetricDifference(node *list1, node *list2);
node *listDifference(node *list1, node *list2);
#endif
