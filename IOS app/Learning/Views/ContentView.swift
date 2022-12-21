//
//  ContentView.swift
//  Learning
//
//  Created by Marjus Nielsen on 2022-03-21.
//

import SwiftUI
import CoreData

struct ContentView: View {

    let viewModel: RunChallenges
    
    let timer = Timer.scheduledTimer(withTimeInterval: 1.0, repeats: true) { timer in
         
    }
    
    var body: some View {
  
        GeometryReader { geometry in
            VStack {
                HStack{
                    Text(viewModel.challenges.activeChallenge.name)
                        .font(.largeTitle)
                   //     .foregroundColor(Color.black)
                    Spacer()
                    Text(viewModel.challenges.activeChallenge.challengeDescription!)
                        .font(.subheadline)
                       // .foregroundColor(Color.black)
                }
                .padding()
                
                Text(viewModel.challenges.activeChallenge.text)
                    .font(.largeTitle)
                    .foregroundColor(Color.black)
                    .cardify(isFaceUp: true)
                
    /*
                Text(modelData.challenges[1].question)
                    .font(.body)
                    .foregroundColor(Color.black)
                    .cardify(isFaceUp: true)
      */
                GeometryReader{ geometry in
                    LazyVGrid(columns: [GridItem(.adaptive(minimum: geometry.size.width/2.1))]){
                        ForEach(viewModel.challenges.activeChallenge.options) { option in
                            Text(option.content)
                                .font(.largeTitle)
                                .cardify(isFaceUp: true)
                                .aspectRatio(1.7, contentMode: .fit)
                        }
                    }
                }
                
             /*
                HStack {
                    Text(modelData.challenges[1].options[0].content)
                        .font(.largeTitle)
                        .cardify(isFaceUp: true)
                    
                    Text(modelData.challenges[1].options[1].content)
                        .font(.largeTitle)
                        .cardify(isFaceUp: true)
                }
                HStack {
                    Text(modelData.challenges[1].options[2].content)
                        .font(.largeTitle)
                        .cardify(isFaceUp: true)
                    
                    Text(modelData.challenges[1].options[3].content)
                        .font(.largeTitle)
                        .cardify(isFaceUp: true)
                }
                */
            }
            .padding()
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    
    var modelData = ModelData()
    
    static var previews: some View {
        ContentView(viewModel: RunChallenges())
         //   .preferredColorScheme(.dark)
            .previewDevice("iPad Air (5th generation)")
            .environmentObject(ModelData())
            .environment(\.managedObjectContext, PersistenceController.preview.container.viewContext)
        
        ContentView(viewModel: RunChallenges())
            .previewDevice("iPhone 13")
            .environmentObject(ModelData())
            .environment(\.managedObjectContext, PersistenceController.preview.container.viewContext)
    }
}
