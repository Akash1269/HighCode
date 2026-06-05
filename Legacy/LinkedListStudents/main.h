#ifndef MAIN_H
  #define MAIN_H
  #define NAME_SIZE 50
  #define CODE_SIZE 20
  
  //enum declaration for use 
  typedef enum {SUCCESS,FAILURE} status;
  typedef enum {FOUND,NOTFOUND} find;
  
  
  // a key contains roll no. and subject code as key
  typedef struct keyType
  {
       int roll;
       char sub_code[CODE_SIZE];
  }key;


  //student record data for 1 student 
  typedef struct studentRecord
  {
        key k;
        char name[NAME_SIZE];
        int marks;
  }student;


  //node for the continuous linked list to be created
  typedef struct nodeType
  {
        student s;
        struct nodeType *next;
  }node;
  
  //functions prototypes for main.c file
  void printMenu();
  void freeList(node *ptr);
  void printMenuShort();
#endif
