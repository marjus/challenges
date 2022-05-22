//
//  LearningApp.swift
//  Learning
//
//  Created by Marjus Nielsen on 2022-03-21.
//

import SwiftUI

@main
struct LearningApp: App {
    
    let persistenceController = PersistenceController.shared
    @StateObject private var viewModel = RunChallenges()
    
    var body: some Scene {
        WindowGroup {
            ContentView(viewModel: viewModel)
                .environmentObject(viewModel)
                .environment(\.managedObjectContext, persistenceController.container.viewContext)
        }
    }
}
