#include <conio.h>
#include <stdio.h>
#define SIZE 5
typedef struct node {
    int data;
    struct node *next;
} node;

typedef struct queue {
    node *front;
    node *rear;
} queue;

typedef enum { FAIL, SUCCESS } sc;

void initialize(queue *ptr) { ptr->front = ptr->rear = NULL; }

sc push(queue *ptr, int d) {
    node *nptr;
    sc s;
    nptr = (node *)malloc(sizeof(node));
    nptr->data = d;
    nptr->next = NULL;

    if (ptr->front == NULL) {
        ptr->front = ptr->rear = nptr;
    } else {
        ptr->rear->next = nptr;
        ptr->rear = nptr;
    }

    s = SUCCESS;
    return s;
}

sc pop(queue *ptr, int *dptr) {
    sc s = SUCCESS;
    node *nptr;
    if (ptr->front == NULL) {
        s = FAIL;
    } else {
        nptr = ptr->front;
        *dptr = nptr->data;
        ptr->front = nptr->next;
        free(nptr);
    }
    return s;
}

main() {
    int c, d;
    sc flag;
    queue q;
    initialize(&q);
abc:
    printf("enter choice\n1.push\n2.pop\n");
    scanf("%d", &c);
    switch (c) {
    case 1: {
        printf("enter element\n");
        scanf("%d", &d);
        flag = push(&q, d);
        if (flag == SUCCESS)
            printf("success\n");
        else
            printf("fail\n");
        break;
    }
    case 2: {
        flag = pop(&q, &d);

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