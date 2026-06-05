/*
  Name:Student Database
  Branch:CSE (DSPD-II)
  Author:Akash Bhayekar 
  Date: 05/02/12 14:36
  Description:Using Linked List Data Structure 
*/

//header files
#include<stdio.h>
#include<conio.h>
#include<string.h>
//user defined header files
#include "main.h"
#include "inputOutput.h"
#include "insertDelete.h"
#include "search.h"
#include "other.h"
#include "setOperations.h"
#include "password.h"


//main function control the program                      
main()
{
      printf("\n                 ||WELCOME TO THE STUDENT RECORDS||               \n");
      int i = 0;
      status sc;
      sc = passwordCheck();
      while(sc == FAILURE && i < 3)
      {
          printf("\n\n\tUser Name OR Password Is Incorect\n");
          printf("\tTry Again..... %d Attempts remaining\a\n",3-i);
          i++;
          sc = passwordCheck();
      }
      if(sc == SUCCESS)
      {     
            node *list1,*list2,*list;//head pointer to the record
            printf("\n\n\t** Successfully Logged In **\n");
            printMenu();
            printf("\n\tChoose Any Data source You Want\n");
            list=createList();
            int choice = 1;
            
            
            while(choice != 0)
            {    printMenuShort();
                 printf("\n\tSelect An Appropriate Choice To Do Operations On List:");
                 scanf("%d",&choice);
                 
                 
                 
                 //switch case statements starts here
                 switch( choice )
                 {
                  case 0:
                  {
                       //for exiting application
                       break;
                  }
                  case 1:
                  {    //for insertion of data
                       printf("\nEnter The Data To Be Inserted\n");
                       list = insertNode(list,scanData());
                       printf("\nData Is Successfully Inserted OR Updated\n");
                       break;                   
                  }
                  case 2:
                  {    //deletion operartion of data
                       key k;
                       printf("\nEnter The Roll no And Subject Code To be Deleted\n");
                       printf("\nRoll No:");
                       scanf("%d",&k.roll);
                       printf("\nSubject Code:");
                       scanf("%s",k.sub_code);
                       status sc;
                       sc=deleteNode(&list,k);
                       if(sc==SUCCESS)
                              printf("\nDelete Operation Is Successful\n");
                       else
                              printf("\nDelete failed Due To Not Found OR List is Empty\n\a");
                       break;    
                  }
                  case 3:
                  {    //check whether list is empty or not 
                       status sc=isEmpty(list);
                       if(sc==SUCCESS)
                              printf("\nThe List Is Empty\n");
                       else
                              printf("\nList Is Not Empty\n");
                       break;
                  }
                  case 4:
                  {    //for searching the record int the list
                       key k;
                       printf("\nEnter The Record To Be Searched\n");
                       printf("\nRoll No:");
                       scanf("%d",&k.roll);
                       printf("\nSubject Code:");
                       scanf("%s",k.sub_code);
                       node *pre = NULL,*cur = NULL;
                       if(searchKey(list,&pre,&cur,k)==FOUND)
                       {
                            printf("\nThe Key Is Found In The Student Records\n");
                            printf("   _____________________________________________________________________ \n");
                            printf("  |             |               |                       |               |\n");
                            printf("  |   Roll No   |   Sub Codes   |    Name Of Student    |     Marks     |\n");
                            printf("  |_____________|_______________|_______________________|_______________|\n");
                            printf("  |             |               |                       |               |\n");
                            printData(cur->s);
                            printf("  |_____________|_______________|_______________________|_______________|\n");
                            printf("\n\n\n");
                       }
                       else
                       {
                           printf("\nThe Key Is Not Found In The Student Records OR List Is Empty\n\a");
                       }
                       break;
                  }
                  case 5:
                  {    //for calculating nuber of records in the list
                       printf("\nNumber Of Records In List Are :%d\n",getNumRecords(list));
                       break;
                  }
                  case 6:
                  {
                       //for calculating number of students having max marks in perticular subject
                       char sub_code[CODE_SIZE];
                       printf("\nFind Students Having Maximum Marks In The Subject Code:");
                       scanf("%s",sub_code);
                       node *max_head=NULL;
                       max_head = getMaxMarks(sub_code,list);
                       if(max_head == NULL)
                                   printf("\nThis Subject Code Does Not Exist In The List\a\n");
                       else
                       {    
                            printf("\nMax Marks In Subject Are:%d\n",max_head->s.marks);
                            printf("\nThe List Of Students Getting Max Marks\n");
                            printList(max_head);
                            freeList(max_head);
                       }
                       break;
                  }
                  case 7:
                  {    //unique list print
                       uniqueList(list);
                       printf("\nUnique List Is As Follows\n");
                       printList(list);
                       break;
                  }
                  case 8:
                  {    //for printing the list 
                       printList(list);
                       break;
                  }
                  case 9:
                  {
                       //for Change File
                       printf("\n\tChoose Any One Of The Following\n");
                       list=createList();
                       break;
                  }
                  case 10:
                  {    //take the union of the two lists
                       printf("\n\tSelect 1st List\n");
                       list1=createList();
                       printf("\n\tSelect 2nd List\n");
                       list2=createList();
                       node *list3;
                       list3 = listUnion(list1,list2);
                       if(list3==NULL)
                             printf("\nThe Union Of Two List Is Null Set\a\n");
                       else
                       {
                           printf("\nThe List Union Is As Folllows\n");
                           printList(list3);
                           freeList(list3);
                       }
                       freeList(list1);
                       freeList(list2);
                       break;
                  }
                  case 11:
                  {
                       //intersection of 2 lists
                       printf("\n\tSelect List1\n");
                       list1=createList();
                       printf("\n\tSelect List2\n");
                       list2=createList();
                       node *list3;
                       list3=listIntersection(list1,list2);
                       if(list3==NULL)
                             printf("\nThe Intersection Of Two List Is Null Set\a\n");
                       else
                       {
                           printf("\nThe List Intersection Is As Folllows\n");
                           printList(list3);
                           freeList(list3);
                       }
                       freeList(list1);
                       freeList(list2);
                       break;
                  }
                  case 12:
                  {
                       //symmetric difference of 2 lists
                       printf("\n\tSelect List1\n");
                       list1=createList();
                       printf("\n\tSelect List2\n");
                       list2=createList();
                       node *list3;
                       list3=listSymmetricDifference(list1,list2);
                       if(list3==NULL)
                             printf("\nThe Symmetric Differnce Of Two List Is Null Set\a\n");
                       else
                       {
                           printf("\nThe List Symmetric Differnce Is As Folllows\n");
                           printList(list3);
                           freeList(list3);
                       }
                       freeList(list1);
                       freeList(list2);
                       break;
                       
                  }
                  case 13:
                  {
                       //difference betn 2 lists
                       printf("\n\tSelect List1\n");
                       list1=createList();
                       printf("\n\tSelect List2\n");
                       list2=createList();
                       node *list3;
                       list3=listDifference(list1,list2);
                       if(list3==NULL)
                             printf("\nThe List Difference{list1-list2) Of Two List Is Null Set\a\n");
                       else
                       {
                           printf("\nThe List Difference{list1-list2) Is As Folllows\n");
                           printList(list3);
                           freeList(list3);
                       }
                       freeList(list1);
                       freeList(list2);
                       break;
                       
                  }
                  case 14:
                  {
                       //difference betn 2 lists
                       printf("\n\tSelect List1\n");
                       list1=createList();
                       printf("\n\tSelect List2\n");
                       list2=createList();
                       node *list3;
                       list3=listDifference(list2,list1);
                       if(list3==NULL)
                             printf("\nThe List Difference{list2-list1} Of Two List Is Null Set\a\n");
                       else
                       {
                           printf("\nThe List Difference{list2-list1} Is As Folllows\n");
                           printList(list3);
                           freeList(list3);
                       }
                       freeList(list1);
                       freeList(list2);
                       break;
                  }
                  default:
                  {
                       printf("\nYou Have Entered Wrong Choice,Please Try Again\a\n");
                       break;
                  }
                  
                  
                 }
                 
                      
            }
            int var;
            printf("\nDo You Store This Updated Data To lists\n1.Yes\t\tELSE.No\n");
            printf("\nWARNING:This Is Gone Replace The Present data In The File\a\n");
            scanf("%d",&var);
            if(var==1)
            {
                    int fileno;
                    printf("\nStore This Updated Data To\n\t1.list1.txt\n\t2.list2.txt\n");
                    scanf("%d",&fileno);
                    if(fileno == 1)
                    {
                         char file1[]="list1.txt";
                         printToFile(list,file1);
                         printf("\nSuccessfuly Stored Data To %s\n",file1);
                    }
                    else if(fileno == 2)
                    {
                         char file2[]="list2.txt";
                         printToFile(list,file2);
                         printf("\nSuccessfuly Stored Data To %s\n",file2);
                    }
                    else
                         printf("\nYou Have Entered Wrong Choice\a\n");
            }
            freeList(list);
            getch();
      }
}

//print only at the time of startup
void printMenu()
{
     printf("   _____________________________________________________________________ \n");
     printf("  |                                                                     |\n");
     printf("  |           POSSIBLE GENERAL OPERATIONS ON STUDENTS RECORD            |\n");
     printf("  |_____________________________________________________________________|\n");
     printf("  |                                                                     |\n");
     printf("  |         0. EXIT From The Application                                |\n");
     printf("  |         1. Add An Entry To The Students Record                      |\n");
     printf("  |         2. Delete An Entry From The Students Record                 |\n");
     printf("  |         3. Check Whether Students Record Is Empty                   |\n");
     printf("  |         4. Search An Entry From The Students Record And Print It    |\n");
     printf("  |         5. Get Number Of Entries In The Students Record             |\n");
     printf("  |         6. Get Maximum Marks For Given Subject Code                 |\n");
     printf("  |         7. Get Unique Students Record OR Remove Duplicates          |\n");
     printf("  |         8. Print All The Student's Record                           |\n");
     printf("  |         9. Change The List You Are Using For Editing                |\n");
     printf("  |_____________________________________________________________________|\n");
     printf("  |                                                                     |\n");
     printf("  |           POSSIBLE SET OPERATIONS ON THE STUDENTS RECORD            |\n");
     printf("  |_____________________________________________________________________|\n");
     printf("  |                                                                     |\n");
     printf("  |         10. Take Union Of Two Students Record                       |\n");
     printf("  |         11. Take Intersection Of Two Students Record                |\n");
     printf("  |         12. Take Symmetric Difference OF Students Record            |\n");
     printf("  |         13. Take List Difference [LIST1 - LIST2]                    |\n");
     printf("  |         14. Take List Difference [LIST2 - LIST1]                    |\n");
     printf("  |_____________________________________________________________________|\n");
}

//print every time of repeatation
void printMenuShort()
{
     printf("   ________________________________MENU_________________________________ \n");
     printf("  |             0.EXIT              |               0.EXIT              |\n");
     printf("  |  1.Insert         2.Delete      |  3.Is Empty         4.Search      |\n");
     printf("  |  5.Size           6.Max Marks   |  7.Unique           8.Print       |\n");
     printf("  |  9.Change List    10.Union      |  11.InterSection    12.Symmetric  |\n");
     printf("  |  13.List DIffernce[1-2]         |  14.List DIffernce[2-1]           |\n");
     printf("  |_________________________________|___________________________________|\n");
}

//for freeing the dynamically allocated memory
void freeList(node *ptr)
{
     node *prev;
     while(ptr!=NULL)
     {
         prev=ptr;
         ptr=ptr->next;
         free(prev);
     }
}
