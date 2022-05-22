//
//  Grammar.swift
//  Learning
//
//  Created by Marjus Nielsen on 2022-05-03.
//

import Foundation


struct Grammar: Hashable, Codable, Identifiable{ 
    var id: Int
    var name: String
    var description: String
    var image: String
    
    func isSameAs(_ grammar: Grammar) -> Bool {
        self.id == grammar.id
    }
}


