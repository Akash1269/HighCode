#include<stdio.h>
#include<conio.h>
#include<string.h>
#include "setOperations.h"


//union of 2 lists
node *listUnion(node *list1,node *list2)
{
     node *tmp1=list1,*tmp2=list2,*list3=NULL,*nptr,*last;
     student s0;
     last=list3=createNode(s0);//a temp node with random data to be freed
     
     while(tmp1!=NULL && tmp2!=NULL)
     {
           if(compareKey(tmp1->s.k,tmp2->s.k)==0)//elements with equal key
           {
               nptr=createNode(tmp1->s);
               tmp1=tmp1->next;
               tmp2=tmp2->next;
           }
           else if(compareKey(tmp1->s.k,tmp2->s.k)==-1)//key1<key2
           {
               nptr=createNode(tmp1->s);
               tmp1=tmp1->next;
           }
           else//key2<key1
           {
               nptr=createNode(tmp2->s);
               tmp2=tmp2->next;
           }
           last->next=nptr;//inserting node in list
           last=nptr;//modify last pointer 
     }
     while(tmp1!=NULL)//copying remaining list
     {
            nptr=createNode(tmp1->s);
            tmp1=tmp1->next;
            last->next=nptr;
            last=nptr;
     }
     while(tmp2!=NULL)//copying remaining list
     {
            nptr=createNode(tmp2->s);
            tmp2=tmp2->next;        
            last->next=nptr;
            last=nptr;   
     }
     last->next=NULL;
     last=list3;//setting last to first temp node to delete it
     list3=list3->next;//actual list 3 head
     free(last);
     return list3;
}

//it is the intersection of two lists
node* listIntersection(node* list1,node *list2)
{
     node *tmp1=list1,*tmp2=list2,*list3=NULL,*nptr,*last;
     student s0;
     last=list3=createNode(s0);//a temp node with random data to be freed
     
     while(tmp1!=NULL && tmp2!=NULL)
     {
           if(compareKey(tmp1->s.k,tmp2->s.k)==1)//elements with equal key
           {
               tmp2=tmp2->next;
           }
           else if(compareKey(tmp1->s.k,tmp2->s.k)==-1)//key1<key2
           {
                tmp1=tmp1->next;
           } 
           else//key2<key1
           {
               nptr=createNode(tmp1->s);
               last->next=nptr;
               last=nptr;
               tmp1=tmp1->next;
               tmp2=tmp2->next;
           }
     }
     last->next=NULL;
     last=list3;//setting last to first temp node to delete it
     list3=list3->next;//actual list 3 head
     free(last);
     return list3;
}


//list difference = list1-list2
node *listDifference(node *list1,node* list2)
{
     node *tmp1=list1,*tmp2=list2,*list3=NULL,*nptr,*last;
     student s0;
     last=list3=createNode(s0);//a temp node with random data to be freed
     
     while(tmp1!=NULL && tmp2!=NULL)
     {
           if(compareKey(tmp1->s.k,tmp2->s.k)==0)//elements with equal key
           {
               tmp1=tmp1->next;
               tmp2=tmp2->next;
           }
           else if(compareKey(tmp1->s.k,tmp2->s.k)==-1)//key1<key2
           {
               nptr=createNode(tmp1->s);
               last->next=nptr;
               last=nptr;
               tmp1=tmp1->next;
           }
           else//key2<key1
           {
               tmp2=tmp2->next;
           }
           
     }
     while(tmp1!=NULL)//copying remaining list
     {
            nptr=createNode(tmp1->s);
            tmp1=tmp1->next;
            last->next=nptr;
            last=nptr;
     }
     last->next=NULL;
     last=list3;//setting last to first temp node to delete it
     list3=list3->next;//actual list 3 head
     free(last);
     return list3;
}



//2 list symmetric differnce = (list1-list2)+(list2-list1)
node *listSymmetricDifference(node *list1,node *list2)
{
     node *tmp1=list1,*tmp2=list2,*list3=NULL,*nptr,*last;
     student s0;
     last=list3=createNode(s0);//a temp node with random data to be freed
     
     while(tmp1!=NULL && tmp2!=NULL)
     {
           if(compareKey(tmp1->s.k,tmp2->s.k)==0)//elements with equal key
           {
               tmp1=tmp1->next;
               tmp2=tmp2->next;
           }
           else if(compareKey(tmp1->s.k,tmp2->s.k)==-1)//key1<key2
           {
               nptr=createNode(tmp1->s);
               tmp1=tmp1->next;
           }
           else//key2<key1
           {
               nptr=createNode(tmp2->s);
               tmp2=tmp2->next;
           }
           last->next=nptr;
           last=nptr;
     }
     while(tmp1!=NULL)//copying remaining list
     {
            nptr=createNode(tmp1->s);
            tmp1=tmp1->next;
            last->next=nptr;
            last=nptr;
     }
     while(tmp2!=NULL)//copying remaining list
     {
            nptr=createNode(tmp2->s);
            tmp2=tmp2->next;        
            last->next=nptr;
            last=nptr;   
     }
     last->next=NULL;
     last=list3;//setting last to first temp node to delete it
     list3=list3->next;//actual list 3 head
     free(last);
     return list3;
}
