//
//  UserChallenge.swift
//  Learning
//
//  Created by Marjus Nielsen on 2022-05-16.
//

import Foundation

// MARK: - UserChallenges
struct UserChallenges: Codable {
    let id: Int
    let key: String
    let activeChallenge: Challenge
    let challenges: [Challenge]

    enum CodingKeys: String, CodingKey {
        case id = "Id"
        case key = "Key"
        case activeChallenge = "ActiveChallenge"
        case challenges = "Challenges"
    }
    
    func empty () -> UserChallenges{
        return self
    }
}

// MARK: - Challenge
struct Challenge: Codable {
    let id: Int
    let name, text: String
    let challengeDescription: String?
    let question: String
    let correctOptionID: Int
    let options: [Option]
    let type, difficultyLevel: Int
    let isOpenForAll: Bool

    enum CodingKeys: String, CodingKey {
        case id = "Id"
        case name = "Name"
        case text = "Text"
        case challengeDescription = "Description"
        case question = "Question"
        case correctOptionID = "CorrectOptionId"
        case options = "Options"
        case type = "Type"
        case difficultyLevel = "DifficultyLevel"
        case isOpenForAll = "IsOpenForAll"
    }
}

// MARK: - Option
struct Option: Codable, Identifiable {
    let id: Int
    let content: String

    enum CodingKeys: String, CodingKey {
        case id = "Id"
        case content = "Content"
    }
}
