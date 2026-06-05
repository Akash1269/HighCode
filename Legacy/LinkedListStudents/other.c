#include<stdio.h>
#include<conio.h>
#include<string.h>
#include "other.h"

//to get number of record in the student
int getNumRecords(node *head)
{    
    int count=0;
    while(head!=NULL)
    {
        count++;
        head=head->next;
    }
    return count;
}


// to check whether list is empty
status isEmpty(node *head)
{
     status sc=FAILURE;
     if(head==NULL)
          sc=SUCCESS;
     return sc;
}   


/*
//get max marks in the given subject code  for larger lists
node *getMaxMarks(char sub_code[],node *head)
{
     node *ptr=head,*max_list=NULL;// max_list is head to the list of student who hav max marks
     int max_marks=0;
     while(ptr!=NULL)
     {
         if(strcmp(sub_code,ptr->s.k.sub_code)==0)
         {
                if(max_marks<ptr->s.marks)//if new max found
                {
                    freeList(max_list);
                    max_list=NULL;
                    max_marks=ptr->s.marks;
                    node *nptr;
                    nptr=createNode(ptr->s);//create node for new linked list
                    nptr->next=max_list;
                    max_list=nptr;
                }
                else if(max_marks==ptr->s.marks)//if the found max is the only max at this step
                {
                    node *nptr;
                    nptr=createNode(ptr->s);
                    nptr->next=max_list;
                    max_list=nptr;
                }
         }
         ptr=ptr->next;
     }
     return max_list;
}
*/            
                     
                    



//get max marks in the given subject code  
node *getMaxMarks(char sub_code[],node *head)
{
     node *ptr=head,*max_list=NULL,*first_max=head;// max_list is head to the list of student who hav max marks
     int max_marks=0; 
     while(ptr!=NULL)//to get the value of max marks
     {
         if(strcmp(sub_code,ptr->s.k.sub_code)==0)
         {
                if(max_marks<ptr->s.marks)
                {
                      first_max=ptr;
                      max_marks=ptr->s.marks;
                }
         }
         ptr=ptr->next;
     }
     ptr=first_max;
     while(ptr!=NULL)//to copy all students data who having max marks
     {
         if(strcmp(sub_code,ptr->s.k.sub_code)==0)
         {
            if(ptr->s.marks==max_marks)
            {
               node *nptr;
               nptr=createNode(ptr->s);//create node for new linked list
               nptr->next=max_list;
               max_list=nptr;
            }
         }
         ptr=ptr->next;
     }
     return max_list;
}



//for finding unique of the list
void uniqueList(node *head)
{
     node *ptr=head;
     node *temp=NULL;
     if(head!=NULL)
     {
           while(ptr->next!=NULL)
           {
                if(compareKey(ptr->s.k,ptr->next->s.k)==0)
                {
                     temp=ptr->next;
                     ptr->next=temp->next;
                     free(temp);
                }
                ptr=ptr->next;
           }
     }
}
                   
