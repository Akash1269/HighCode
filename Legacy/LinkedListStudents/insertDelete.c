#include<stdio.h>
#include<conio.h>
#include "insertDelete.h"


//for inserting data in the list
node* insertNode(node* head,student s)
{
       if(isEmpty(head)==SUCCESS)
       {       
               node *nptr;
               nptr=createNode(s);
               head=nptr;//if list is empty
       }
       else
       {
              node *prev=NULL,*current=NULL;
              find f;
              f=searchKey(head,&prev,&current,s.k);
              if(f==FOUND)
                   current->s=s;//replace old data with new one
              else
              {
                  node *nptr;
                  nptr=createNode(s);
                  if(prev==NULL) //for head get changed,node inserted at start
                  {
                       nptr->next=current;
                       head=nptr;
                  }
                  else //for no head change
                  {
                       nptr->next=current;
                       prev->next=nptr;
                  }
              }
       }
              
       return head;//if head get updated
}

//for deleting given node from the list
status deleteNode(node **hpptr,key k)
{
    node* head,*prev=NULL,*current=NULL;
    status sc=FAILURE;
    head=*hpptr;
    find f;
    f=searchKey(head,&prev,&current,k);//searching node in list to delete
    if(f==FOUND)
    {
         if(prev==NULL)   //if it is at the start of list
         {
             head=current->next;
             free(current);
         }
         else//if anywhere else
         {       
             prev->next=current->next;
             free(current);
         }
         sc=SUCCESS;
    }
    *hpptr=head;
    return sc;
}



