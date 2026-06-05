#include <stdio.h>
#include <conio.h>
// status code
typedef enum
{
    SUCCESS,
    FAILURE
} status;

// structure node declaration
typedef struct node_type
{
    int data;
    struct node_type *next;
} node;

// 1.create list function
node *create_list(int n)
{
    node *nptr, *ptr;
    int i;
    ptr = NULL;
    for (i = 0; i < n; i++)
    {
        nptr = (node *)malloc(sizeof(node));
        nptr->data = 3 * i;
        nptr->next = ptr;
        ptr = nptr;
    }
    return ptr;
}

// 2.traverse list function
void print_list(node *ptr)
{
    while (ptr != NULL)
    {
        printf("%d\n", ptr->data);
        ptr = ptr->next;
    }
}

// 3.delete list function
status delete_list(node *ptr)
{
    node *nptr;
    status sc = SUCCESS;
    if (ptr == NULL)
        sc = FAILURE;
    while (ptr != NULL)
    {
        nptr = ptr;
        ptr = ptr->next;
        free(nptr);
    }
    return sc;
}

// 4.insert at start
node *insert_at_start(node *ptr, int data)
{
    node *nptr;
    nptr = (node *)malloc(sizeof(node));
    nptr->next = ptr;
    nptr->data = data;
    ptr = nptr;
    return ptr;
}

// 5.insert at end of list
node *insert_at_end(node *head, int data)
{
    node *nptr, *ptr;
    ptr = head;
    nptr = (node *)malloc(sizeof(node));
    nptr->next = NULL;
    nptr->data = data;
    if (ptr == NULL)
    {
        head = nptr;
    }
    while (ptr->next != NULL)
    {
        ptr = ptr->next;
    }
    ptr->next = nptr;
    return head;
}

// 6.delete starting node of list
node *delet_at_start(node *head, int *dptr)
{
    node *nptr;
    nptr = head;
    if (head != NULL)
    {
        *dptr = head->data;
        head = head->next;
        free(nptr);
    }
    return head;
}

// 7.delete last node of list
node *delet_at_end(node *head, int *dptr)
{
    node *nptr;
    nptr = head;
    node *ptr = head;
    if (head != NULL)
    {
        while (ptr->next != NULL)
        {
            nptr = ptr;
            ptr = ptr->next;
        }
        *dptr = ptr->data;
        free(ptr);
        nptr->next = NULL;
    }
    return head;
}

// 8.combine 2 lists in same list
node *concate(node *list1, node *list2)
{
    node *ptr, *var;
    ptr = list1;
    if (list1 == NULL)
        var = list2;
    else
    {
        while (ptr->next != NULL)
        {
            ptr = ptr->next;
        }
        ptr->next = list2;
        var = list1;
    }
    return var;
}

// 9.reverse the list
node *reverse_list(node *list)
{
    node *head, *middle, *trail;
    middle = NULL;
    head = list;
    while (head != NULL)
    {
        trail = middle;
        middle = head;
        head = head->next;
        middle->next = trail;
    }
    return middle;
}

// 10.insert after the node
status insert_after(node *p, node *q)
{
    status sc = SUCCESS;
    if (p == NULL || q == NULL)
    {
        sc = FAILURE;
    }
    else
    {
        q->next = p->next;
        p->next = q;
    }
    return sc;
}

// 11.insert between
status insert_bet(node **hpptr, node *p, node *q, node *r)
{
    // insert q between p and r
    status sc = SUCCESS;
    if (q == NULL)
        sc = FAILURE;
    else
    {
        if (p == NULL)
        {
            q->next = r;
            *hpptr = q;
        }
        else
        {
            p->next = q;
            q->next = r;
        }
    }
    return sc;
}

// 12.insert before node
status insert_before(node **hpptr, node *p, node *q)
{
    status sc = SUCCESS;
    node *head = *hpptr, *ptr;
    if (p != NULL && head != NULL)
    {
        if (p == head)
        {
            q->next = head;
            *hpptr = q;
        }
        else
        {
            ptr = head;
            while (ptr->next != p)
            {
                ptr = ptr->next;
            }
            ptr->next = q;
            q->next = p;
        }
    }
    else if (p == NULL && head == NULL)
    {
        q->next = NULL;
        *hpptr = q;
    }
    else
        sc = FAILURE;
    return sc;
}

// 13.delete after node
status delete_after_node(node *p)
{
    status sc = SUCCESS;
    node *q;
    if (p != NULL && p->next != NULL)
    {
        q = p->next;
        p->next = q->next;
        free(q);
        q = NULL;
    }
    else
        sc = FAILURE;
    return sc;
}

// main function
main()
{
    node *head = NULL;
    int choice, wish = 1;
    while (wish == 1)
    {
        printf("what do u want to do\n");
        printf("\t    1.create list\n\
            2.print list\n\
            3.delete list\n\
            4.insert at start\n\
            5.insert at end\n\
            6.delete at start\n\
            7.delete at end\n\
            8.concatanet\n\
            9.reverse the list\n\
            10.insert after\n\
            11.insert between\n\
            12.insert before\n\
            13.delte after node\n");
        scanf("%d", &choice);
        switch (choice)
        {
        case 1:
        {
            int n;
            printf("enter the no of elements u want to create list\n");
            scanf("%d", &n);
            head = create_list(n);
            break;
        }
        case 2:
        {
            printf("the list is as follows\n");
            print_list(head);
            break;
        }
        case 3:
        {
            if ((delete_list(head)) == SUCCESS)
                printf("successfuly deleted\n");
            else
                printf("no node found\n");
            head = NULL;
            break;
        }
        case 4:
        {
            int data;
            printf("enter data to be inserted at start\n");
            scanf("%d", &data);
            head = insert_at_start(head, data);
            break;
        }
        case 5:
        {
            int data;
            printf("enter data to be inserted at end\n");
            scanf("%d", &data);
            head = insert_at_end(head, data);
            break;
        }
        case 6:
        {
            int d = 0;
            head = delet_at_start(head, &d);
            printf("deleted elment at start is %d:", d);
            break;
        }
        case 7:
        {
            int d;
            head = delet_at_end(head, &d);
            printf("deleted elment at end is %d:", d);
            break;
        }
        case 8:
        {
            node *head2;
            head2 = create_list(10);
            print_list(concate(head, head2));
            break;
        }
        case 9:
        {
            head = reverse_list(head);
            printf("successfully reversed\n");
            break;
        }
        case 10:
        {
            int i, j;
            node *p, *q;
            p = head;
            printf("where do u want to insert after node");
            scanf("%d", &j);
            for (i = 0; i < (j - 1); j++)
            {
                p = p->next;
            }
            q->next = NULL;
            q->data = 99;
            if (insert_after(p, q) == SUCCESS)
                printf("successfuly inserted\n");
            else
                printf("error\n");
            break;
        }
        case 11:
        {
            int i, j;
            node *p = head, *q, *r;
            printf("where do u want to insert after node");

            scanf("%d", &j);
            for (i = 0; i < (j - 1); j++)
                p = p->next;
            r = r->next;
            q->next = NULL;
            q->data = 99;
            if (insert_bet(&head, p, q, r) == SUCCESS)
                printf("successfuly inserted\n");
            else
                printf("error\n");
            break;
        }
        case 12:
        {
            int i, j;
            node *p = head, *q;
            printf("where do u want to insert before node");

            scanf("%d", &j);
            for (i = 0; i < (j - 1); j++)
                p = p->next;
            q->next = NULL;
            q->data = 99;
            if (insert_before(&head, p, q) == SUCCESS)
                printf("successfuly inserted\n");
            else
                printf("error\n");
            break;
        }
        case 13:
        {
            int i, j;
            node *p = head;
            printf("where do u want to insert before node");

            scanf("%d", &j);
            for (i = 0; i < (j - 1); j++)
                p = p->next;
            if ((delete_after_node(p)) == SUCCESS)
                printf("successfuly inserted\n");
            else
                printf("error\n");
            break;
        }
        default:
        {
            printf("u hav entered wrong choice\n");
        }
        }
        printf("do u want to continue\n1.for yes\n");
        scanf("%d", &wish);
    }
}