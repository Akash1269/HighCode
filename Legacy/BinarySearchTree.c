#include <conio.h>
#include <stdio.h>
#include <string.h>
#define SIZE 100
typedef enum { SUCCESS, FAILURE } status;
typedef struct keyTag {
    int i;
} key;
typedef struct dataTag {
    key k;
    char name[20];
} data;
typedef struct treeTag {
    data d;
    struct treeTag *left;
    struct treeTag *right;
} tree;

// Queue Code Starts here for BFS
typedef struct que {
    tree *list[SIZE];
    int f;
    int r;
    int count;
} q;

void initialize(q *ptr) {
    ptr->f = 0;
    ptr->r = -1;
    ptr->count = 0;
}

status push(q *ptr, tree *t) {
    status flag = SUCCESS;
    if (ptr->count == SIZE) {
        flag = FAILURE;
    } else {
        ptr->r = ((ptr->r) + 1) % SIZE;
        ptr->list[ptr->r] = t;
        (ptr->count)++;
    }
    return flag;
}

tree *pop(q *ptr) {
    tree *t = NULL;
    if (ptr->count > 0) {

        t = ptr->list[ptr->f];
        ptr->f = ((ptr->f) + 1) % SIZE;
        (ptr->count)--;
        if (ptr->count == 0)
            initialize(ptr);
    }
    return t;
}
// Queue Code Ends here

void visit(tree *root) {
    printf("record-\t");
    printf("%s\t%d\n", root->d.name, root->d.k.i);
}

void bredthFirst(tree *root) {

    q *qu;
    initialize(qu);
    tree *child;
    push(qu, root);
    while (qu->count != 0) {
        child = pop(qu);
        visit(child);
        if (child->left)
            push(qu, child->left);
        else if (child->right)
            push(qu, child->right);
    }
}

int keyCompare(key k1, key k2) {
    if (k1.i > k2.i)
        return 1;
    if (k1.i < k2.i)
        return -1;
    else
        return 0;
}

tree *createTree() {
    tree *t, *nptr, *l, *r;

    nptr = (tree *)malloc(sizeof(tree));
    strcpy(nptr->d.name, "left");
    nptr->d.k.i = 2;
    nptr->left = NULL;
    nptr->right = NULL;
    l = nptr;
    nptr = (tree *)malloc(sizeof(tree));
    strcpy(nptr->d.name, "right");
    nptr->d.k.i = 9;
    nptr->left = NULL;
    nptr->right = NULL;
    r = nptr;
    nptr = (tree *)malloc(sizeof(tree));
    strcpy(nptr->d.name, "root");
    nptr->d.k.i = 5;
    nptr->left = l;
    nptr->right = r;
    t = nptr;
    return t;
}

void preOrder(tree *root) {
    if (root) {
        visit(root);
        preOrder(root->left);
        preOrder(root->right);
    }
}
void inOrder(tree *root) {
    if (root) {
        inOrder(root->left);
        visit(root);
        inOrder(root->right);
    }
}
void postOrder(tree *root) {
    if (root) {
        postOrder(root->left);
        postOrder(root->right);
        visit(root);
    }
}

int numNodes(tree *root) {
    int ret_value;
    int num_left;
    int num_right;
    if (!root)
        ret_value = 0;
    else {
        num_left = numNodes(root->left);
        num_right = numNodes(root->right);
        ret_value = 1 + num_left + num_right;
    }
    return ret_value;
}

tree *copy(tree *root) {
    if (root) {
        tree *nptr, *l, *r;
        nptr = (tree *)malloc(sizeof(tree));
        nptr->d = root->d;
        l = copy(root->left);
        r = copy(root->right);
        nptr->left = l;
        nptr->right = r;
        return nptr;
    } else
        return NULL;
}

int numLeaves(tree *root) {
    int ret_value;
    int num_left;
    int num_right;
    if (!root)
        ret_value = 0;
    else if (!root->left && !root->right)
        ret_value = 1;
    else {
        num_left = numNodes(root->left);
        num_right = numNodes(root->right);
        ret_value = num_left + num_right;
    }
    return ret_value;
}

int height(tree *root) {
    int ret_value, htl, htr;
    if (!root)
        ret_value = -1;
    else if (!root->left && !root->right)
        ret_value = 0;
    else {
        htl = height(root->left);
        htr = height(root->right);
        if (htl > htr)
            ret_value = htl + 1;
        else
            ret_value = htr + 1;
    }
    return ret_value;
}

void mirrorImg(tree *root) {
    if (root) {
        tree *temp;
        temp = root->left;
        root->left = root->right;
        root->right = temp;
        mirrorImg(root->left);
        mirrorImg(root->right);
    }
}

tree *search(tree *root, key k) {
    tree *found_node = NULL;
    if (!root)
        found_node = NULL;
    else {
        if (keyCompare(root->d.k, k) == 0)
            found_node = root;
        else if (keyCompare(root->d.k, k) == 1)
            found_node = search(root->left, k);
        else
            found_node = search(root->right, k);
    }
    return found_node;
}

tree *insert(tree *root, tree *node) {
    tree *p = root;
    int done = 0;
    if (!root)
        root = node;
    else {
        while (done != 1) {
            if (keyCompare(node->d.k, p->d.k) == -1) {
                if (p->left)
                    p = p->left;
                else {
                    p->left = node;
                    done = 1;
                }
            } else if (keyCompare(node->d.k, p->d.k) == 1) {
                if (p->right)
                    p = p->right;
                else {
                    p->right = node;
                    done = 1;
                }
            } else {
                printf("\nduplicate found cant insert\n");
            }
        }
    }
    return root;
}

void delete_node(tree **p) {
    tree *q, *prev;
    if (!*p)
        printf("\nerrror\n");
    else if (!(*p)->right) {
        q = *p;
        *p = q->left;
        free(q);
    } else if (!(*p)->left) {
        q = *p;
        *p = q->right;
        free(q);
    } else // solution to (A)
    {
        for (q = (*p)->left; q->right;) {
            q = q->right;
        }
        q->right = (*p)->right;
        q = *p;
        *p = q->left;
        free(q);
    }
    /*
    else//solution to (B)
    {
        for(q=*p->right;q->left;)
        {
             q=q->left;
        }
        q->left=*p->left;
        q=*p;
        *p=q->right;
        free(q);
    }*/
    /*
    else//solution to (C)
    {
        tree *r;
        for(r=q=*p->left;q->right;)
        {
             r=q;
             q=q->right;
        }
        r->right=q->left;
        q->left=*p->left;
        q->right=*p->right;
        r=*p;
        *p=q;
        free(q);
    }*/
    /*
    else//solution to (D)
    {
        tree *r;
        for(r=q=*p->right;q->left;)
        {
             r=q;
             q=q->left;
        }
        r->left=q->right;
        q->right=*p->right;
        q->left=*p->left;
        r=*p;
        *p=q;
        free(q);
    }
    */
}

status delete_key(tree *root, key k) {
    status s = FAILURE;
    tree *found_node = NULL, *prev = NULL;
    if (!root) {
        found_node = NULL;
        prev = NULL;
    } else {
        if (keyCompare(root->d.k, k) == 0)
            found_node = root;
        else if (keyCompare(root->d.k, k) == 1) {
            found_node = search(root->left, k);
            prev = root;
        } else {
            found_node = search(root->right, k);
            prev = root;
        }
    }
    if (found_node) {
        if (prev->left == (root))
            delete_node(&(prev->left));
        else
            delete_node(&(prev->right));
        s = SUCCESS;
    }
    return s;
}

main() {
    tree *root;
    int choice = 1;
    root = createTree();
    while (choice != 0) {
        printf("\nenter the choice to continue \n1.pre\n2.in\n3.post\n4.num\n5.numleaves\n");
        printf("6.height\n7.mirror\n8.search\n9.insert\n10.Copy\n11.Delete\n");
        scanf("%d", &choice);
        switch (choice) {
        case 0:
            break;
        case 1: {
            preOrder(root);
            break;
        }
        case 2: {
            inOrder(root);
            break;
        }
        case 3: {
            postOrder(root);
            break;
        }
        case 4: {
            printf("%d", numNodes(root));
            break;
        }
        case 5: {
            printf("%d", numLeaves(root));
            break;
        }
        case 6: {
            printf("%d", height(root));
            break;
        }
        case 7: {
            mirrorImg(root);
            break;
        }
        case 8: {
            key k;
            tree *temp;
            printf("\nenter the key to be searched:");
            scanf("%d", &(k.i));
            temp = search(root, k);
            if (temp)
                visit(temp);
            else
                printf("notfound\n");
            break;
        }
        case 9: {
            tree *node;
            node = (tree *)malloc(sizeof(tree));
            node->left = NULL;
            node->right = NULL;
            printf("\nenter the data to be inserted\n");
            printf("key int:");
            scanf("%d", &(node->d.k.i));
            printf("name:");
            scanf("%s", (node->d.name));
            root = insert(root, node);
            inOrder(root);
            break;
        }
        case 10: {
            tree *new_tree;
            new_tree = copy(root);
            preOrder(new_tree);
            break;
        }
        case 11: {
            key k;
            printf("\nenter the key to be searched:");
            scanf("%d", &(k.i));
            delete_key(root, k);
            preOrder(root);
            break;
        }
        case 12: {
            bredthFirst(root);
            break;
        }
        }
    }
    getch();
}
