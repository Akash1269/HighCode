#include <conio.h>
#include <stdio.h>
#define SIZE 10
typedef struct stack {
    int list[SIZE];
    int top;
} stack;

typedef enum { FAIL, SUCCESS } sc;

void initialize(stack *ptr) { ptr->top = 0; }

sc push(stack *ptr, int d) {
    sc flag;
    if (ptr->top >= SIZE) {
        flag = FAIL;
    } else {
        ptr->list[ptr->top] = d;
        (ptr->top)++;
        flag = SUCCESS;
    }
    return (flag);
}

sc pop(stack *ptr, int *dptr) {
    sc flag;
    if (ptr->top == 0) {
        flag = FAIL;
    } else {
        (ptr->top)--;
        *dptr = ptr->list[ptr->top];
        flag = SUCCESS;
    }
    return (flag);
}

main() {
    int c, d;
    sc flag;
    stack s;
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
