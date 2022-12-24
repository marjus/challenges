<template>  


<div class="row row-cols-2">
    <div class="col" v-for="option in challengeStore.activeChallenge.Options" :key="option.id">  
        <div class="form-group" @click="selectOption(option)" v-if="challengeStore.editMode">
            <div class="alert alert-dismissible border option" :class="{ 'alert-success': option.IsCorrect, 'alert-light': !option.IsCorrect  }">
                <input class="form-control" title="Valmøguleiki" placeholder="Valmøguleiki" v-model="option.Content">
                <label v-if="option.IsCorrect" class="form-check-label">R&#xE6;tt svar</label>
            </div>
        </div>
        <div v-else>
            <div class="alert alert-dismissible border option" :class="{ 'alert-success': option.IsCorrect, 'alert-light': !option.IsCorrect  }">
                <h6>
                    {{ option.Content }}
                </h6>
            </div>
        </div>
    </div>
</div>

</template>

<script setup>
    import { useChallengeStore } from "@/stores/challenge";

    const challengeStore = useChallengeStore();

    const selectOption = (o) => {  challengeStore.setCorrectOption(o) };  
</script>

<style scoped>
    .options{
        width: 100%;
    }
    .option{
        /* margin: 10px; */
    }
</style>