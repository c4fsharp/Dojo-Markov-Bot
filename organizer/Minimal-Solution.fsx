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

// just bigrams, simple approach

// break a string into "words"

let separators = [|' '; '\n' |]
let wordify (text:string) = 
    text.Split separators 
    |> Array.filter (fun word -> word <> "")
    
// group sequence of words into bigrams

let bigramify (text:string[]) = text |> Seq.windowed 2

// find all the bigrams that begin with a given word
// and return all the possible "next words"

let followingWords word (bigrams:string[] seq) =
    bigrams
    |> Seq.filter (fun bigram -> bigram.[0] = word)
    |> Seq.map (fun bigram -> bigram.[1])
    |> Seq.toArray    

// pickup a random next word from possible ones.
// if no candidate is found, return None.

let rng = System.Random ()
let nextWord (bigrams:string[] seq) word =
    let candidates =        
        bigrams
        |> followingWords word
    match candidates with
    | [||] -> None
    | _ -> 
        let index = rng.Next(candidates.Length)
        candidates.[index] |> Some

// given a text sample and a starting word,
// search for a next word and append it
// to a sentence, until no next word is found
// or the last word is followed by ., so
// that the results "looks like" a full sentence.
let generateFrom (start:string) (sample:string) =
    let bigrams = 
        sample
        |> wordify
        |> bigramify
    let next = nextWord bigrams
    let rec generate sentence word =
        match (next word) with
        | None -> sentence
        | Some(nextWord) -> 
            let sentence = sentence + " " + nextWord
            if nextWord.EndsWith(".")
            then sentence
            else generate sentence nextWord
    generate start start

// ... see it in action
sample |> generateFrom "I"
sample |> generateFrom "you"