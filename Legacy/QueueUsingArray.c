#include <conio.h>
#include <stdio.h>
#define SIZE 10
typedef struct queue {
    int list[SIZE];
    int front;
    int rear;
    int count;
} queue;

typedef enum { FAIL, SUCCESS } sc;

void initialize(queue *ptr) {
    ptr->front = 0;
    ptr->rear = -1;
    ptr->count = 0;
}

sc push(queue *ptr, int d) {
    sc flag;
    if (ptr->count >= SIZE) {
        flag = FAIL;
    } else {
        ptr->rear = (ptr->rear + 1) % SIZE;
        ptr->list[ptr->rear] = d;
        ptr->count++;
        flag = SUCCESS;
    }
    return (flag);
}

sc pop(queue *ptr, int *dptr) {
    sc flag;
    if (ptr->count == 0) {
        flag = FAIL;
    } else {
        *dptr = ptr->list[ptr->front];
        ptr->front = (ptr->front + 1) % SIZE;
        (ptr->count)--;
        flag = SUCCESS;
    }
    return (flag);
}

main() {
    int c, d;
    sc flag;
    queue s;
    queue *sptr;
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
