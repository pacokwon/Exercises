(*
Define a function prob2 that takes in a string and returns a new string that
ends with a newline character '\n'.  The function appends a newline character
to the given string to produce a new one, but if the input string already ends
with a newline character, the function does not append an additional newline
character. Note that a string in F# is indeed, an array of characters, and each
character in a string can be accessed through a dot operator.
For example, str.[0] returns the first character of the string str. Also, one
can get the length of a string s by calling a function String.length:
String.length s returns the length of the string s.
Finally, you can append two strings using the + operator.
*)

let prob2 str =
    if str = "" then "\n"
    elif str.[String.length str - 1] = '\n' then str
    else str + "\n"
