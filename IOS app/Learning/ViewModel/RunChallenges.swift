//
//  RunChallenges.swift
//  Learning
//
//  Created by Marjus Nielsen on 2022-05-16.
//

import Foundation

class RunChallenges: ObservableObject{
    var challenges: UserChallenges
    
    init(){
        challenges = ModelData().userChallenges
    }
    
    func loadChallenges () async  {
        guard let url = URL(string: "https://learnchallengetest1.azurewebsites.net/challenges") else {
            print("invalid url")
            return
        }
        
        do {
            let (data, _) = try await URLSession.shared.data(from: url)

            if let decodedResponse = try? JSONDecoder().decode(UserChallenges.self, from: data) {
                challenges = decodedResponse
            }
        } catch {
            print("Invalid data")
        }
    }
}
