(*
All source material for this dojo can be found at:
https://github.com/c4fsharp/Dojo-Markov-Bot

It's MIT licensed - use it, share it, modify it.
*)

(*
Introduction
+++++++++++++++++++++++++++++++++++++++++++++++++

The goal of the dojo is to create a program that
generates human-looking sentences, by reproducing
patterns that exist in a text sample.

To achieve this, we will break the sample into
n-grams. A n-gram is a succession of n words in
the text. n-grams capture common word sequences;
If we generate text following existing n-grams,
we'll get a "plausible" sequence of words, 
without having to understand how language works.

We'll guide you through writing a markov bot
generating text based on bigrams (sequences of 2
words), and then suggest directions to 
explore further!
*)

// Sample text: "What a Wonderful World"
// http://en.wikipedia.org/wiki/What_a_Wonderful_World

let sample = """
I see trees of green, red roses, too,
I see them bloom, for me and you
And I think to myself
What a wonderful world.

I see skies of blue, and clouds of white,
The bright blessed day, the dark sacred night
And I think to myself
What a wonderful world.

The colors of the rainbow, so pretty in the sky,
Are also on the faces of people going by.
I see friends shaking hands, sayin', "How do you do?"
They're really sayin', "I love you."

I hear babies cryin'. I watch them grow.
They'll learn much more than I'll ever know
And I think to myself
What a wonderful world

Yes, I think to myself
What a wonderful world"""

(* 
Chapter 1: Breaking the input into bi-grams
+++++++++++++++++++++++++++++++++++++++++++++++++

Your goal here is to take the input text, and
break it into a collection of bigrams, that is, 
consecutive words. For instance, 
"the colors of the rainbow" produces 4 bigrams:
- the,colors
- colors,of
- of,the
- the,rainbow
*)

// <useful bits of code for inspiration>

let test = "the colors of the rainbow"
test.Split ' '

let numbers = [ 1 .. 10 ]
let byFive =
    numbers 
    |> Seq.windowed 5 
    |> Seq.toArray

// </useful bits of code for inspiration> 

// TODO: WRITE A FUNCTION 
// let bigramify (text:string) = ...
// THAT BREAKS A TEXT INTO AN ARRAY OF BIGRAMS

let bigramify (text:string) =
    // [ YOUR CODE GOES HERE ]
    Array.empty<string[]>


(* 
Chapter 2: Finding next word candidates
+++++++++++++++++++++++++++++++++++++++++++++++++

Now that you have isolated bi-grams, given a 
starting word, you will need to find all the 
words that could follow it. To do this, you need
to extract all the bi-grams where the first word
matches, and return all the next words in the 
selected bi-grams, in an array.
*)

// <useful bits of code for inspiration>

// an array of pairs = arrays of integers
let pairs = 
    [| [| 1; 2 |]
       [| 1; 3 |]
       [| 4; 2 |] 
    |]

let endsWithTwo = 
    pairs 
    |> Seq.filter (fun pair -> pair.[1] = 2)
    |> Seq.toArray

let secondElements = 
    pairs |> Array.map (fun pair -> pair.[1])

// </useful bits of code for inspiration>

// TODO: WRITE A FUNCTION 
// let nextWords ... = ...
// THAT RETURNS ALL WORDS FOLLOWING A GIVEN WORD.

let nextWords (bigrams:string[] seq) (word:string) =
    // [ YOUR CODE GOES HERE ]
    [| "this"; "is"; "an"; "example" |]
    
    
(* 
Chapter 3: Generating a "sentence"
+++++++++++++++++++++++++++++++++++++++++++++++++

Almost there! The only thing we need now is to
start from an initial word, find a next word 
using the bi-grams from the sample, append it to
the sentence, and repeat until we find no next
word. There are many ways to do this, recursion
being one option.
*)

// <useful bits of code for inspiration>

// string concatenation
let word1 = "hello"
let word2 = "world"
let concatenated = word1 + ", " + word2

// a recursion example

let repeatNtimes times word =
    // create a recursive function
    let rec repeatNtimes counter sentence =
        if counter > times 
        then sentence
        else 
            let updated = sentence + " " + word
            repeatNtimes (counter+1) updated 
    // call it, starting count at 1 and
    // with an "empty sentence"
    repeatNtimes 1 ""

repeatNtimes 3 "Hello?"

// </useful bits of code for inspiration>


// TODO: WRITE A FUNCTION 
// let generateWords ... = ...
// THAT BREAKS SAMPLE TEXT INTO BI-GRAMS, AND
// STARTING FROM AN INPUT WORD, PRODUCES A
// SENTENCE BY APPENDING WORDS.

let generateWords (sample:string) (firstWord:string) =
    // TODO
    // 1. extract bi-grams from sample
    // 2. recursively append words based
    // on bi-grams, starting from firstWord
    "not implemented yet!"


(* 
Next episode: Have fun!
+++++++++++++++++++++++++++++++++++++++++++++++++

By now, you should have a function generateWords
that produces "variations" based on the song
"What a Wonderful World".

The next step is entirely up to you!

Here are a couple of ideas you could explore:

1. The song is fairly short, and doesn't have
many sentences/patterns. You will get more 
interesting/fun results using longer samples. Or
mixing samples of different origins.

Project Gutenberg is a great resource for this;
it contains public domain classics:
https://www.gutenberg.org/
We included two novels from there, included as
raw text files (jeeves.txt and tarzan.txt):
https://www.gutenberg.org/ebooks/8164
https://www.gutenberg.org/ebooks/81

We also included a home-made compilation of
TechCrunch blog posts, initrode.txt, which can be
used to make a fun startup idea generator :)

2. Bi-grams are short patterns. You can get more
"realistic looking" results by using tri-grams, 
or 4, 5, ... - grams. For instance, with 
tri-grams, you would look for sequences of 3
words, like "I/see/trees", "I/see/them", ... and
generate forward:
- starting with "I/see/" 
- pick (for instance) "them",
- continue with "see/them"

3. Improve performance, by storing n-grams in a
suitable data structure?

4. Being smarter when parsing the sample. 
Splitting on white space is very crude, and makes
it difficult to find (for instance) where a
sentence starts or ends, and identifying good
points to stop generating words.

5. Create a Markov buddy: write a bot that 
responds to user input, with a sentence that is
"reasonable". 

So... have fun, and hopefully produce realistic
or fun "human looking text"
*)