#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define NAME_SIZE 50
#define AUTH_SIZE 50
#define SIZE 5 /*SIZE used for size of array of records*/
struct library {
    char name[NAME_SIZE];
    char author[AUTH_SIZE];
    int year; /*both int can be unsighned*/
    int num;  /*num used for no.of copies*/
} lib[SIZE];
char empty_str[] = {'\0'};

void reset(struct library l[]) /*reset function for records*/
{
    int i;
    for (i = 0; i < SIZE; i++) {
        l[i].name[0] = '\0';
        l[i].author[0] = '\0';
        l[i].year = 0;
        l[i].num = 0;
    }
}

void scan(struct library l[], int n) /*for scanning array of structure*/
{
    int i;
    for (i = 0; i < n; i++) {
        scanf("%49s", l[i].name);
        scanf("%49s", l[i].author);
        scanf("%d%d", &l[i].year, &l[i].num);
    }
}

void print(struct library l[], int n) /*for printing the array of structure*/
{
    int i;
    printf("\n\nrecord is as follows:-\n");
    for (i = 0; i < n; i++) {
        if (l[i].name[0] != '\0') {
            printf("\n%s\t", l[i].name);
            printf("%s\t", l[i].author);
            printf("%d\t%d\n", l[i].year, l[i].num);
        }
    }
}

void sort(struct library l[]) /*sorting records first by auth and then name*/
{
    int i, j, tmp1, tmp2, sort = 0;
    struct library temp;
    for (i = 0; i < SIZE && sort == 0; i++) {
        sort = 1;
        for (j = 0; j < (SIZE - 1); j++) {
            tmp1 = strcmp(l[j].author, l[j + 1].author);
            if (tmp1 > 0) {
                temp = l[j];
                l[j] = l[j + 1];
                l[j + 1] = temp;
                sort = 0;
            }
            if (tmp1 == 0) /*for same author sorting by name*/
            {
                tmp2 = strcmp(l[j].name, l[j + 1].name);
                if (tmp2 > 0) {
                    temp = l[j];
                    l[j] = l[j + 1];
                    l[j + 1] = temp;
                    sort = 0;
                }
            }
        }
    }
}

int isfull(struct library l[]) /*check full(1) or not(0)*/
{
    int i, var = 1;
    for (i = 0; i < SIZE; i++) {
        if (l[i].name[0] == '\0') {
            var = 0;
            i = SIZE; /*i=SIZE for exiting loop*/
        }
    }
    return var;
}

int isempty(struct library l[]) /*check empty(1) or not(0)*/
{
    int i, var = 1;
    for (i = 0; i < SIZE; i++) {
        if (l[i].name[0] != '\0') {
            var = 0;
            i = SIZE; /*i=SIZE for exiting loop*/
        }
    }
    return var;
}

int search(struct library l[], char name[], char author[]) /*serch on basis of author and name*/
{ /*found return index and -1 if not found*/
    int i, var = -1, tmp1, tmp2;
    for (i = 0; i < SIZE; i++) {
        tmp1 = strcmp(l[i].name, name);
        if (tmp1 == 0) {
            tmp2 = strcmp(l[i].author, author);
            if (tmp2 == 0) {
                var = i;
                i = SIZE; /*i=SIZE for exiting loop*/
            }
        }
    }
    return var;
}

void insert(struct library l[], char name[], char author[], int year,
            int num) /*func to insert one struct data in list*/
{
    int temp, t;
    temp = search(l, name, author);
    if (temp != (-1)) /*updation if found in records*/
    {
        l[temp].year = year;
        l[temp].num = num;
        printf("task complete(updation)\n");
    } else {
        if (isfull(l) == 1) {
            printf("task incomplete(insertion)due to no space\n");
        } else {
            t = search(l, empty_str, empty_str);
            strcpy(l[t].name, name);
            strcpy(l[t].author, author);
            l[t].year = year;
            l[t].num = num;
            printf("task complete(insertion)\n");
        }
    }
}

void del(struct library l[], char name[], char author[]) {
    int i;
    i = search(l, name, author);
    if (i != -1) {
        l[i].name[0] = '\0';
        l[i].author[0] = '\0';
        l[i].year = 0;
        l[i].num = 0;
        printf("task complete(deletion)\n");
    } else
        printf("task incomplete(deletion)due to not found in library\n");
}

int active(struct library l[]) {
    int i, var = 0;
    for (i = 0; i < SIZE; i++) {
        if (l[i].name[0] != '\0') {
            var++;
        }
    }
    return var;
}

void topauthor(struct library l[], char name[]) {
    int i, temp = 0, var, varindex = 0;
    for (i = 0; i < SIZE; i++) {
        var = strcmp(l[i].name, name);
        if (l[i].num > temp && var == 0) {
            temp = l[i].num;
            varindex = i;
        }
    }
    printf("\nname of author is:- %s", l[varindex].author);
}

void list_unique(struct library l[]) {
    int i, j, tmp1, tmp2;
    for (i = 0; i < SIZE; i++) {
        if (l[i].name[0] != '\0') {
            for (j = i + 1; j < SIZE; j++) {
                if (l[j].name[0] != '\0') {
                    tmp1 = strcmp(l[i].name, l[j].name);
                    if (tmp1 == 0) {
                        tmp2 = strcmp(l[i].author, l[j].author);
                        if (tmp2 == 0) {
                            if ((l[i].year) > (l[j].year)) {
                                l[j].name[0] = '\0';
                                l[j].author[0] = '\0';
                                l[j].year = 0;
                                l[j].num = 0;
                            } else {
                                l[i].name[0] = '\0';
                                l[i].author[0] = '\0';
                                l[i].year = 0;
                                l[i].num = 0;
                            }
                        }
                    }
                }
            }
        }
    }
}

void list_union(struct library listin1[]) {
    int i, n, k = 0;
    FILE *fp1;
    struct library listin2[SIZE], listout[SIZE * 2];
    memset(listout, 0, sizeof(listout));
    reset(listin2);
    fp1 = fopen("list2.txt", "r");
    if (!fp1) {
        printf("\nError: list2.txt not found\n");
        return;
    }
    fscanf(fp1, "%d", &n);
    for (i = 0; i < n && i < SIZE; i++) {
        fscanf(fp1, "%49s", listin2[i].name);
        fscanf(fp1, "%49s", listin2[i].author);
        fscanf(fp1, "%d", &listin2[i].year);
        fscanf(fp1, "%d", &listin2[i].num);
    }
    fclose(fp1);
    for (i = 0; i < SIZE; i++) {
        if (listin1[i].name[0] != '\0') {
            listout[k] = listin1[i];
            k++;
        }
        if (listin2[i].name[0] != '\0') {
            listout[k] = listin2[i];
            k++;
        }
    }
    list_unique(listout);
    sort(listout);
    printf("sorted union of 2 list is as follows\n");
    print(listout, SIZE * 2);
}

void unique_intersection(struct library l[]) /*unique for no. of copies for intersection*/
{
    int i, j, tmp1, tmp2;
    for (i = 0; i < SIZE; i++) {
        if (l[i].name[0] != '\0') {
            for (j = i + 1; j < SIZE; j++) {
                if (l[j].name[0] != '\0') {
                    tmp1 = strcmp(l[i].name, l[j].name);
                    tmp2 = strcmp(l[i].author, l[j].author);
                    if ((tmp1 == 0) && (tmp2 == 0)) {
                        if ((l[i].num) < (l[j].num)) {
                            l[j].name[0] = '\0';
                            l[j].author[0] = '\0';
                            l[j].year = 0;
                            l[j].num = 0;
                        } else {
                            l[i].name[0] = '\0';
                            l[i].author[0] = '\0';
                            l[i].year = 0;
                            l[i].num = 0;
                        }
                    }
                }
            }
        }
    }
}

void intersection(struct library listin1[]) {
    int i, n, k = 0, found;
    FILE *fp1;
    struct library listin2[SIZE], listout[SIZE];
    reset(listout);
    reset(listin2);
    fp1 = fopen("list2.txt", "r");
    if (!fp1) {
        printf("\nError: list2.txt not found\n");
        return;
    }
    fscanf(fp1, "%d", &n);
    for (i = 0; i < n && i < SIZE; i++) {
        fscanf(fp1, "%49s", listin2[i].name);
        fscanf(fp1, "%49s", listin2[i].author);
        fscanf(fp1, "%d", &listin2[i].year);
        fscanf(fp1, "%d", &listin2[i].num);
    }
    fclose(fp1);
    unique_intersection(listin1);
    unique_intersection(listin2);
    for (i = 0; i < SIZE; i++) {
        if (listin1[i].name[0] != '\0') {
            found = search(listin2, listin1[i].name, listin1[i].author);
            if (found != -1) {
                if (listin1[i].num < listin2[found].num) {
                    listout[k] = listin1[i];
                    k++;
                } else {
                    listout[k] = listin2[found];
                    k++;
                }
            }
        }
    }
    sort(listout);
    printf("sorted intersection of 2 lists is as follows\n");
    print(listout, SIZE);
}

void set_difference(struct library listin1[]) {
    int i, n, k = 0, found;
    FILE *fp1;
    struct library listin2[SIZE], listout[SIZE];
    reset(listout);
    reset(listin2);
    fp1 = fopen("list2.txt", "r");
    if (!fp1) {
        printf("\nError: list2.txt not found\n");
        return;
    }
    fscanf(fp1, "%d", &n);
    for (i = 0; i < n && i < SIZE; i++) {
        fscanf(fp1, "%49s", listin2[i].name);
        fscanf(fp1, "%49s", listin2[i].author);
        fscanf(fp1, "%d", &listin2[i].year);
        fscanf(fp1, "%d", &listin2[i].num);
    }
    fclose(fp1);
    for (i = 0; i < SIZE; i++) {
        if (listin1[i].name[0] != '\0') {
            found = search(listin2, listin1[i].name, listin1[i].author);
            if (found == -1) {
                listout[k] = listin1[i];
                k++;
            }
        }
    }
    sort(listout);
    printf("sorted list difference is as follows\n");
    print(listout, SIZE);
}
void symmetric_difference(struct library listin1[]) {
    int n, i, k = 0, found;
    FILE *fp1;
    struct library listin2[SIZE], listout[SIZE];
    reset(listout);
    reset(listin2);
    fp1 = fopen("list2.txt", "r");
    if (!fp1) {
        printf("\nError: list2.txt not found\n");
        return;
    }
    fscanf(fp1, "%d", &n);
    for (i = 0; i < n && i < SIZE; i++) {
        fscanf(fp1, "%49s", listin2[i].name);
        fscanf(fp1, "%49s", listin2[i].author);
        fscanf(fp1, "%d", &listin2[i].year);
        fscanf(fp1, "%d", &listin2[i].num);
    }
    fclose(fp1);
    for (i = 0; i < SIZE; i++) {
        if (listin1[i].name[0] != '\0') {
            found = search(listin2, listin1[i].name, listin1[i].author);
            if (found == -1) {
                listout[k] = listin1[i];
                k++;
            }
        }
        if (listin2[i].name[0] != '\0') {
            found = search(listin1, listin2[i].name, listin2[i].author);
            if (found == -1) {
                listout[k] = listin2[i];
                k++;
            }
        }
    }
    sort(listout);
    printf("\nsorted list symmetric difference is as follows\n");
    print(listout, SIZE);
}

int main() {
    int n = 0, i, choice, repeat = 1, printvar, year, num;
    char name[NAME_SIZE], author[AUTH_SIZE];
    FILE *fp;
    reset(lib);
    printf("\t\t\t**Welcome to library records**\n\n");
    fp = fopen("list1.txt", "r");
    if (!fp) {
        printf("list1.txt not found, starting with empty records\n");
    } else {
        fscanf(fp, "%d", &n);
        for (i = 0; i < n && i < SIZE; i++) {
            fscanf(fp, "%49s", lib[i].name);
            fscanf(fp, "%49s", lib[i].author);
            fscanf(fp, "%d", &lib[i].year);
            fscanf(fp, "%d", &lib[i].num);
        }
        fclose(fp);
    }

    while (repeat == 1) /*to continue the app or exit*/
    {
        printf("\n\nPick ur choice....\n\
      0.reset\n\
      1.insertion\n\
      2.deletion\n\
      3.get active recs\n\
      4.is empty\n\
      5.is full\n\
      6.get topmost book author\n\
      7.list unique \n\
      8.list union\n\
      9.list intersection\n\
      10.list difference(1-2)\n\
      11.list symmetric difference\n");
        scanf("%d", &choice);
        switch (choice) {
        case 0: {
            reset(lib);
            printf("\nreset succesful\n");
            break;
        }
        case 1: {
            printf("enter the data to inserted in library\n");
            scanf("%49s%49s", name, author);
            scanf("%d%d", &year, &num);
            insert(lib, name, author, year, num);
            break;
        }
        case 2: {
            printf("enter name and author to be deleted from library\n");
            scanf("%49s%49s", name, author);
            del(lib, name, author);
            break;
        }
        case 3: {
            printf("\nno. of active records are %d", active(lib));
            break;
        }
        case 4: {
            if (isempty(lib) == 1)
                printf("the record is empty\n");
            else
                printf("record is not empty\n");
            break;
        }
        case 5: {
            if (isfull(lib) == 1)
                printf("record is full\n");
            else
                printf("record is not full\n");
            break;
        }
        case 6: {
            printf("enter the name of book\n");
            scanf("%49s", name);
            topauthor(lib, name);
            break;
        }
        case 7: {
            list_unique(lib);
            printf("\nduplicates has been removed\n");
            break;
        }
        case 8: {
            list_union(lib);
            break;
        }
        case 9: {
            intersection(lib);
            break;
        }
        case 10: {
            set_difference(lib);
            break;
        }
        case 11: {
            symmetric_difference(lib);
            break;
        }
        default: {
            printf("entered choice is wrong\n");
            break;
        }
        }
        sort(lib);
        n = active(lib);
        fp = fopen("list1.txt", "w");
        fprintf(fp, "%d\n", n);
        for (i = 0; i < SIZE; i++) {
            if (lib[i].name[0] != '\0') {
                fprintf(fp, "\n%s\t", lib[i].name);
                fprintf(fp, "%s\t", lib[i].author);
                fprintf(fp, "%d\t", lib[i].year);
                fprintf(fp, "%d\n", lib[i].num);
            }
        }
        fclose(fp);
        printf("do u want to print the record\n1.yes\n2.no\n");
        scanf("%d", &printvar);
        if (printvar == 1) {
            print(lib, SIZE);
        }
        printf("\n\nwant to continue\n1.yes\n2.no\n");
        scanf("%d", &repeat);
    }
    return 0;
}
