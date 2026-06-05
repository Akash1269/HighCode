#include<stdio.h>
#include<conio.h>
#include<string.h>
#include "password.h"

//for login menu username and password
status passwordCheck()
{
    status sc=FAILURE;
    char temp[256]={0},password[]="a",name[]="a",user[10],c;
    int i=0;
    printf("\n\tEnter User Name: ");
    gets(user);
    if(strcmp(name,user)==0)
    {
         printf("\tEnter Password: ");
         do 
         {
               c=getch();
               if(isprint(c)) 
               {
                    temp[i++]=c;
                    printf("%c",'*');
               }
               else if(c==8&&i)
               {
                  temp[i--]='\0';
                  printf("\b \b");
               }
         }while(c!=13);
         if(!strcmp(temp, password))
              sc=SUCCESS;
    }
    return sc;
}
