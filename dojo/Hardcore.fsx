(*
All source material for this dojo can be found at:
https://github.com/c4fsharp/Dojo-Markov-Bot

It's MIT licensed - use it, share it, modify it.
*)

(*
If you picked this script, you opted for the 
"Hardcore" version - you're mostly on your own!
The Guided.fsx script file contains a more guided
version, with some hints/suggestions on how you
could approach the problem.

The goal of the dojo is to create a program that
generates human-looking sentences, by reproducing
patterns that exist in a text sample.

To achieve this, we will break the sample into
n-grams. A n-gram is a succession of n words in
the text. n-grams capture common word sequences;
If we generate text following existing n-grams,
we'll get a "plausible" sequence of words, 
without having to understand how language works.

To get us started, let's build first a program 
based on bi-grams, sequences of two words. 

What you want is to break the sample text into
bi-grams, and then, starting from an initial 
word, generate a sequence of words by randomly
selecting the next one among bigrams where the
first element matches the input word.

For instance, using the sample
"The colors of the rainbow, so pretty in the sky,
Are also on the faces of people going by.", you
would produces a bunch of bigrams:
- the,colors
- colors,of
- of,the
- the,rainbow
...

If you gave your code "the" as input, it would
find 4 matching bi-grams:
- the,colors
- the,rainbow
- the,sky
- the,faces
... you could pick either colors, rainbow, sky or
faces as a next word, at random. If you picked
"rainbow", you would then repeat starting from 
that word, with one successor "so", and repeat.

That's it - make it work!
*)

// Sample text: What a Wonderful World
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