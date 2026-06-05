#include<stdio.h>
#include<conio.h>
#include "inputOutput.h"


//for getting list by any means
node *createList()
{
     int fileno,var;
     node *list=NULL;
     printf("\n  1. Scan Data From The File\t");
     printf("2. Enter Data Manually\n\n  ");
     scanf("%d",&var);
     if(var == 1)//scan data from file
     {
          printf("\n  Which File Do You Want To Use \n\n  1.List1  2.list2\n  ");
          scanf("%d",&fileno);
          if(fileno == 1)//from file list1.txt
          {
               char file1[]="list1.txt";
               list = createListFromFile(file1);
               printf("\nThe Data Scanned From %s Is As Follows\n",file1);
          }
          else if(fileno == 2)//from file list2.txt
          {
               char file2[]="list2.txt";
               list = createListFromFile(file2);
               printf("\nThe Data Scanned From %s Is As Follows\n",file2);
          }
          else
              printf("\nYou Have Entered Wrong Choice\a\n");
          printList(list);
     }
     else if(var == 2)//list to be entered manually
     {
          int n;
          printf("\nENTER THE DATA MANUALLY\n");
          printf("\nEnter The Size Of The List To  Be Create\n");
          scanf("%d",&n);
          list = createListFromInput(n);
     }
     else
         printf("\nYou Have Entered Wrong Choice\a\n");
         
     return list;
}




//for scanning data from the user and passing it in struct 
student scanData()
{
     student s;
     char n[]={' '};
     printf("\nroll no:");
     scanf("%d",&s.k.roll);
     printf("sub code:");
     getchar();
     gets(s.k.sub_code);
     printf("name of student:");
     gets(s.name);
     strcat(s.name,n);
     printf("marks:");
     scanf("%d",&s.marks);
     printf("\n");
     return s;       //returns a struct student 
}


//for creating list from console input
node* createListFromInput(int n)
{
      int i;
      node *head=NULL;
      for(i=0;i<n;i++)
      {
            head=insertNode(head,scanData());//scan data from user
      }
      return head;
      //head to the list created
}

//create node using struct student
node *createNode(student s) 
{
     node *nptr;
     nptr=(node *)malloc(sizeof(node));//dynamic memory allocation
     nptr->s=s;
     nptr->next=NULL;
     return nptr;//pointer to new node created
} 


//scans data from files and create list
/*node *createListFromFile(char file_name[])
{
        node *head=NULL;
        student s;int i,n;
        FILE *fp;
        fp=fopen(file_name,"r");
        fscanf(fp,"%d\n",&n);
        for(i=0;i<n;i++)
        {
              fscanf(fp,"\n%d\t",&s.k.roll);
              fscanf(fp,"%s\t",s.k.sub_code);
              fscanf(fp,"%s\t",s.name);
              fscanf(fp,"%d\n",&s.marks);
              head=insertNode(head,s);//link this node to the list
        }
        fclose(fp);
        return head;
}*/
node *createListFromFile(char file_name[])
{
        node *head=NULL;
        student s;
        int i,n;
        FILE *fp;
        fp=fopen(file_name,"r");
        if(fp)
        {
           fscanf(fp,"%d\n",&n);
           for(i=0;i<n;i++)
           {
              fscanf(fp,"%d\n",&s.k.roll);
              fscanf(fp,"%s\n",s.k.sub_code);
              fgets(s.name,sizeof(s.name),fp);
              fscanf(fp,"%d\n",&s.marks);
              head=insertNode(head,s);//link this node to the list
           }
           fclose(fp);
        }
        else
            printf("\nFile Not Found Create Empty File First\a\n");
        return head;
}



//for printing data of one struct to screen
void printData(student s)
{
     int n;
     n=strlen(s.name);
     s.name[n-1]='\0';
     printf("  |  %d\t\t|  %-6s\t|  %-15s\t|  %d\t\t|\n",s.k.roll,s.k.sub_code,s.name,s.marks);
}

//to print the whole list
void printList(node *ptr)
{
    if(isEmpty(ptr)==SUCCESS)
        printf("\n This List Is Empty\a\n");
    else
    {
        printf("\n\n                       THE LIST IS AS FOLLOWS                        \n");
        printf("   _____________________________________________________________________ \n");
        printf("  |             |               |                       |               |\n");
        printf("  |   Roll No   |   Sub Codes   |    Name Of Student    |     Marks     |\n");
        printf("  |_____________|_______________|_______________________|_______________|\n");
        printf("  |             |               |                       |               |\n");
        while(ptr!=NULL)
        {
            printData(ptr->s);
            ptr=ptr->next;
        }
        printf("  |_____________|_______________|_______________________|_______________|\n");
        printf("\n\n\n");
    }
}
         
         
//storing data to the file              
void printToFile(node *head,char file_name[])
{
      node *ptr=head;
      FILE *fp;
      int no=getNumRecords(head),n;
      fp=fopen(file_name,"w");
      if(fp)
      {
        fprintf(fp,"%d\n",no);
        while(ptr!=NULL)
        {
           fprintf(fp,"%d\n",ptr->s.k.roll);
           fprintf(fp,"%s\n",ptr->s.k.sub_code); 
           n=strlen(ptr->s.name);
           ptr->s.name[n-1]='\0';
           fputs(ptr->s.name,fp);
           fprintf(fp,"\n");
           fprintf(fp,"%d\n",ptr->s.marks);
           ptr=ptr->next;
        }
        fclose(fp);
      }
      else 
           printf("\nFile Not Found First Create Blank File Then Try Again\n\a");
}           
                


