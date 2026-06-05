#include <ctype.h>
#include <stdio.h>
#include <string.h>
#ifdef _WIN32
#include <conio.h>
#else
#include <termios.h>
static int getch(void) {
  struct termios old, new;
  int ch;
  tcgetattr(0, &old);
  new = old;
  new.c_lflag &= ~(ICANON | ECHO);
  tcsetattr(0, TCSANOW, &new);
  ch = getchar();
  tcsetattr(0, TCSANOW, &old);
  return ch;
}
#endif
#include "password.h"

// for login menu username and password
status passwordCheck() {
  status sc = FAILURE;
  char temp[256] = {0}, password[] = "a", name[] = "a", user[10], c;
  int i = 0;
  printf("\n\tEnter User Name: ");
  fgets(user, sizeof(user), stdin);
  user[strcspn(user, "\n")] = '\0';
  if (strcmp(name, user) == 0) {
    printf("\tEnter Password: ");
    do {
      c = getch();
      if (isprint(c)) {
        temp[i++] = c;
        printf("%c", '*');
      } else if (c == 8 && i) {
        temp[i--] = '\0';
        printf("\b \b");
      }
    } while (c != 13);
    if (!strcmp(temp, password))
      sc = SUCCESS;
  }
  return sc;
}
