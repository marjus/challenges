//
//  ModelData.swift
//  Learning
//
//  Created by Marjus Nielsen on 2022-05-03.
//

import Foundation
import Combine

final class ModelData: ObservableObject{
/*    var grammar: [Grammar] = load("Grammar.json")
    var challenges: [Challenge] = load("challenge.json")
*/
    var userChallenges: UserChallenges = load("UserChallenges.json")
}

func load<T: Decodable>(_ filename: String) -> T{
    let data: Data
    
    guard let file = Bundle.main.url(forResource: filename, withExtension: nil)
    else{
        fatalError("Could not find file \(filename) in main bundle")
    }
    
    do{
        data = try Data(contentsOf: file)
    } catch {
        fatalError("Could not find file \(filename) in main bundle: \n\(error)")
    }
    
    do{
        let decoder = JSONDecoder()
        return try decoder.decode(T.self, from: data)
    } catch {
        fatalError("Could not parse \(filename) as \(T.self): \(error)")
    }
}
