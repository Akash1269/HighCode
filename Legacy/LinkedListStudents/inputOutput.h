#ifndef INPUTOUTPUT_H
  #define INPUTOUTPUT_H
  #include "insertDelete.h"
  #include "other.h"
  #include "main.h"
  node *createNode(student s);
  student scanData();
  void printData(student s);
  void printList(node *ptr);
  void printToFile(node *head,char file_name[]);
  node *createList();
  node *createListFromFile(char file_name[]);
  node *createListFromInput(int n);
#endif
