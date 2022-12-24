// stores/users.js
import { defineStore } from 'pinia'
// Import axios to make HTTP requests
import axios from "axios"

export const useChallengeStore = defineStore("challenge",{
    state: () => ({
        challenges: [],
        activeChallenge: {},
        editMode: false
    }),
    getters: {
        getChallenges(state){
            return state.challenges
          }
    },
    actions: {
        async fetchChallenges() {
            try {
              const data = await axios.get('https://learnchallengetest1.azurewebsites.net/Challenges/GetChallengeList')
                this.challenges = data.data
              }
              catch (error) {
                alert(error)
                console.log(error)
            }
        },
        async saveChallenge() {
            try {
                alert("putting " + this.activeChallenge.Id);
                // await axios.put('https://learnchallengetest1.azurewebsites.net/Challenges/' + this.activeChallenge.Id, {
                //     this.activeChallenge.
                // })
            }
            catch(error) {
                alert(error)
                console.log(error)
            }
        }
        async setActive(challenge){
            this.activeChallenge = challenge
        },
        async setCorrectOption(option){
            
            this.activeChallenge.Options.foreach(o=> o.IsCorrect = false);

            var correct = this.activeChallenge.Options.find((opt) => opt.Id === option.Id);
            if(correct){
                correct.IsCorrect = true;
            }
        }
        // async deleteChallenge(challenge){
        //     this.challenges.push(recipe);
        // }
    },
})