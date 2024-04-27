import sys

def count_word_occurrences(file_path, word):
    occurrences = []
    search_word_lower = word.lower()

    line_number = 1  # line counter
    
    with open(file_path, 'r') as file:
        for line in file:
            line_lower = line.lower()
            if search_word_lower in line_lower:
                if 1 <= line_number <= 14:
                    phase = "Phase 1"
                elif 16 <= line_number <= 19:
                    phase = "Phase 2"
                elif 21 <= line_number <= 22:
                    phase = "Phase 3"
                elif 23 < line_number <= 27:
                    phase = "Phase 4"
                else:
                    phase = "Phase 5"
                    
                occurrences.append((line_number, line.strip(), phase)) # adding line number, line itself, and phase
            line_number += 1  # Increment line counter

    return occurrences

if __name__ == "__main__":
    if len(sys.argv) != 3: #number of arguments passed to this script
        sys.exit(1)

    file_path = sys.argv[1] # the file path to the file where we search argument
    word_to_search = sys.argv[2] # the word argument

    occurrences = count_word_occurrences(file_path, word_to_search)

    for occurrence in occurrences:
        print(f"Line: {occurrence[0]}; Word: {word_to_search}; {occurrence[2]}")
