// stores/users.js
import { defineStore } from 'pinia'
// Import axios to make HTTP requests
import axios from "axios"

export const useChallengeStore = defineStore("challenge",{
    state: () => ({
        challenges: [],
        activeChallenge: {},
        activeChallengeIndex: Number,
        editMode: false,
        runMode: false,
        axiosMessage: " "
    }),
    getters: {
        getChallenges(state){
            return state.challenges
          }
    },
    actions: {
        async fetchChallenges() {
            try {
              const data = await axios.get('https://learnchallengeapi.azurewebsites.net/api/challenges')
                this.challenges = data.data
              }
              catch (error) {
                alert(error)
                console.log(error)
            }
        },
        async loadRandom() {
            if(this.challenges && this.challenges.length > 0){
                this.activeChallengeIndex = 0;
                this.activeChallenge = this.challenges[this.activeChallengeIndex];
            }
        },
        async loadNext() {
            if(this.challenges && this.challenges.length > this.activeChallengeIndex +1){
                this.activeChallengeIndex += 1;
                this.activeChallenge = this.challenges[this.activeChallengeIndex];
            }
        },
        async deleteChallenge(challenge){
            try {
                
                if(challenge.id && challenge.id>0){
                    const res = await axios.delete('https://learnchallengeapi.azurewebsites.net/api/challenges/' + challenge.id);
                    
                    if(res.status != 3){
                        this.axiosMessage =  res.status + " " + res.statusText;
                    }
                }
                else{
                    this.axiosMessage = "nothing to delete";
                }
            }
            catch(error) {
                alert(error)
                console.log(error)
            }
        },
        async saveChallenge(challenge) {
            try {
                var res = {};

                if(challenge.id && challenge.id>0){
                    res = await axios.put('https://learnchallengeapi.azurewebsites.net/api/challenges/' + challenge.id,  challenge);
                }
                else{
                    res = await axios.post('https://learnchallengeapi.azurewebsites.net/api/challenges/',  challenge);
                }

                if(res.status > 297){
                    this.axiosMessage =  res.status + " " + res.statusText;
                }
            }
            catch(error) {
                alert(error)
                console.log(error)
            }
        },
        async setActive(challenge){
            this.activeChallenge = challenge
        },
        async newEmpty(){
            const newChallenge = {options: [{},{},{},{}] };

            this.setActive(newChallenge);
            this.editMode = true; 
        },
        async setCorrectOption(option){
            
            this.activeChallenge.options.forEach(o=> o.isCorrect = false);

            var correct = this.activeChallenge.options.find((opt) => opt.id === option.id);
            if(correct){
                correct.isCorrect = true;
            }
        }
        // async deleteChallenge(challenge){
        //     this.challenges.push(recipe);
        // }
    },
})