// stores/users.js
import { defineStore } from 'pinia'
// Import axios to make HTTP requests
import axios from "axios"

export const useChallengeStore = defineStore("challenge",{
    state: () => ({
        challengeData: {},
    }),
    getters: {
        getChallenges(state){
            return state.challengeData.Challenges
          }
    },
    actions: {
        async fetchChallenges() {
            try {
              const data = await axios.get('https://learnchallengetest1.azurewebsites.net/Challenges/GetAllChallenges')
                this.challengeData = data
              }
              catch (error) {
                alert(error)
                console.log(error)
            }
        }
    },
})