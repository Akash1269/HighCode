#include <conio.h>
#include <stdio.h>
#define SIZE 5
typedef struct node {
    int data;
    struct node *next;
} node;
typedef struct stack {
    node *top;
} stack;

typedef enum { FAIL, SUCCESS } sc;

void initialize(stack *nptr) { nptr->top = NULL; }

sc push(stack *ptr, int d) {
    node *nptr;
    sc s;
    nptr = (node *)malloc(sizeof(node));
    nptr->data = d;
    nptr->next = ptr->top;

    ptr->top = nptr;

    s = SUCCESS;
    return s;
}
sc pop(stack *ptr, int *dptr) {
    sc s = SUCCESS;
    node *nptr;
    if (ptr->top == NULL) {
        s = FAIL;
    } else {
        nptr = ptr->top;
        *dptr = nptr->data;
        ptr->top = nptr->next;
        free(nptr);
    }
    return s;
}

main() {
    int c, d;
    sc flag;
    stack s;
    node n;
    stack *sptr;
    sptr = &s;
    initialize(sptr);
abc:
    printf("enter choice\n1.push\n2.pop\n");
    scanf("%d", &c);
    switch (c) {
    case 1: {
        printf("enter element\n");
        scanf("%d", &d);
        flag = push(sptr, d);
        if (flag == SUCCESS)
            printf("success\n");
        else
            printf("fail\n");
        break;
    }
    case 2: {
        flag = pop(sptr, &d);

        if (flag == SUCCESS) {
            printf("success\n");
            printf("\nremoved element  %d\n", d);
        } else
            printf("fail\n");
        break;
    }
    default: {
        printf("wrong");
    }
    }
    goto abc;
    getch();
}
