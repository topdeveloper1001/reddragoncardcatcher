#include <stdio.h>
#include <stdlib.h>

#include <inject.h>

int main(int argc, char *argv[]) {
#ifndef DEBUG
    libinject_log(NULL);
#endif

    if (argc != 3) {
        printf("usage: inject <pid> <module_path.so>\n");
        return EXIT_FAILURE;
    }

    pid_t pid = atoi(argv[1]);
    const char *library = argv[2];

    if (libinject_inject(pid, library) == 0) {
        printf("SUCCESS\n");
        return EXIT_SUCCESS;
    }

    printf("FAILURE\n");
    return EXIT_FAILURE;
}
