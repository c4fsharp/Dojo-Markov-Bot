# Markov Bot Dojo

A Markov Bot is a simple computer program built to simulate a conversation. 
Such programs are often designed to engage in small talk with the aim of 
passing the Turing test by fooling the conversational partner into thinking 
that the program is a human. Markov Bots pull from an existing text, and 
create human-looking (hopefully) sentences by stringing together sequences 
following a Markov chain.

So... how does it work?

Starting from a text like the song "What a wonderful world", you break the
text into pairs of successive words (aka bigrams). For instance,

> "I see trees of green, red roses, too,
> I see them bloom, for me and you"

would become "I -> see", "see -> trees", "trees -> of", and so on and so 
forth. Once this is done, you simply feed the program a starting word, and
pick one of its successors at random. For instance, "I" is followed by "see",
and then "see" can be followed by either "trees" or "them", and so on and 
so forth. By applying this over and over again, you could generate for
instance the following song:

> I see trees of green, red roses, too,
> I see trees of people going by.
> I see friends shaking hands, sayin', "I love you."
>
> I hear babies cryin'. I think to myself
> What a wonderful world

This dojo provides a guided script (and a "hardcore" one) to build a basic
Markov Bot - and then, it's up to you! Some possible extensions are suggested,
but the main goal is to have fun with text (there are a couple of interesting 
sample texts provided), and go for it :)
