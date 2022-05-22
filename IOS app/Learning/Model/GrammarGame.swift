//
//  GrammarGame.swift
//  Learning
//
//  Created by Marjus Nielsen on 2022-05-07.
//

import Foundation

struct GrammarGame<CardContent> {
    var cards: [Grammar]
    
    init(numberOfCards : Int, createGrammarContent: (Int) -> CardContent){
        cards = Array<Grammar>()
        
        // Add word cards
        for cardIndex in 0..<numberOfCards {
            let cardContent = createGrammarContent(cardIndex)
            cards.append(
                Grammar(id: cardIndex, name: "Banan", description: "Ein banan", image: cardContent))
        }
    }
        
    struct Grammar: Identifiable{
        var id: Int
        var name: String
        var description: String
        var image: CardContent
        
        func isSameAs(_ grammar: Grammar) -> Bool {
            self.id == grammar.id
        }
    }
}
