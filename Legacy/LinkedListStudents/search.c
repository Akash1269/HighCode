#include "search.h"
#include <stdio.h>
#include <string.h>

int compareKey(key k1, key k2) {
    int ret_value;
    if (k1.roll > k2.roll)
        ret_value = 1;
    else if (k1.roll < k2.roll)
        ret_value = -1;
    else {
        ret_value = strcmp(k1.sub_code,
                           k2.sub_code); // the compare value will depend on sub code only
    }
    return ret_value;
    // 1 for k1>k2
    //-1 for k1<k2
    // 0 for k1=k2
}

find searchKey(node *head, node **prev, node **current, key k) {
    find f = NOTFOUND;
    int flag = 0; // for terminating condition
    node *pre = NULL, *cur = head;
    while (flag == 0 && cur != NULL) // unless list ends or flag is 1
    {
        if (compareKey(k, cur->s.k) == 0) // for checking if present in list and then stop
        {
            f = FOUND;
            flag = 1;
        } else if (compareKey(k, cur->s.k) == -1) // if key is less than current node key then stop
        {
            flag = 1;
        } else // increament
        {
            pre = cur;
            cur = cur->next;
        }
    }
    *prev = pre;    // returns previous node pointer
    *current = cur; // returns current node pointer
    return f;       // returns weather it is found or not found
}

// not in use its alternate search function
// for searching for given key in list
/*
node* search_rec(node *ptr,key k)
{
    int found=0;
    node *ret_value=NULL;
    if(ptr!=NULL)
    {
         while(ptr!= NULL && compare_key(ptr->s.k,k)!= 0)
         {
             if(compare_key(ptr->s.k,k)==0)
             {
                 ret_value=ptr;
                 found=1;// if found then terminate loop
             }
             ptr=ptr->next;
         }
    }
    else
         ptr=NULL;
    return ptr;
    //return ret_value;
    //returns NULL for empty and node not found
    //returns pointer to the node where node is found
}
*/
