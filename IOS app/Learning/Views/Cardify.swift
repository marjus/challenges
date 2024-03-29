//
//  Cardify.swift
//  Learning
//
//  Created by Marjus Nielsen on 2022-05-03.
//

import SwiftUI

struct Cardify: AnimatableModifier {
    var rotation: Double
    
    
    
    var isFaceUp: Bool{
        rotation < 90
    }
    
    
    init(isFaceUp: Bool)
    {
        rotation = isFaceUp ? 0 : 180
       
    }
    
    var animatableData: Double{
        get{ rotation }
        set{ rotation = newValue }
    }
    
    func body(content: Content) -> some View {
        
        ZStack{
            Group{
                RoundedRectangle(cornerRadius: cornerRadius).fill(Color.white)
                RoundedRectangle(cornerRadius: cornerRadius).stroke( lineWidth: lineWidth)
                content
            }.opacity(isFaceUp ? 1 : 0)
            
            RoundedRectangle(cornerRadius: cornerRadius).fill().opacity(isFaceUp ? 0 : 1)
            
        }
        .rotation3DEffect(Angle.degrees(rotation), axis: (0,1,0))
    }
    
    private let cornerRadius : CGFloat = 10.0
    private let lineWidth: CGFloat = 3.0
}

extension View{
    func cardify(isFaceUp: Bool) -> some View{
        self.modifier(Cardify(isFaceUp: isFaceUp))
    }
}
