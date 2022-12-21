// stores/users.js
import { defineStore } from 'pinia'
// Import axios to make HTTP requests
import axios from "axios"

export const useRecipeStore = defineStore("recipe",{
    state: () => ({
        recipes: [],
    }),
    getters: {
        getRecipes(state){
            return state.recipes
          }
    },
    actions: {
        async fetchRecipes() {
            try {
              const data = await axios.get('https://rcpttest.azurewebsites.net/api/recipes/get')
                this.recipes = JSON.parse(data.data)
              }
              catch (error) {
                alert(error)
                console.log(error)
            }
        }
    },
})