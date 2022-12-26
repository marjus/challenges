<template >
    <div class="container">
        <div class="border challenge" v-if="challengeStore.editMode">
            <h6>Nummar</h6>
            <input v-model="challengeStore.activeChallenge.OrderInSequence">
            <h6>Navn</h6>
            <input v-model="challengeStore.activeChallenge.Name">
            <h6>Spurningur</h6>
            <input v-model="challengeStore.activeChallenge.Question">
            <h6>Tekstur</h6>
            <input v-model="challengeStore.activeChallenge.Text">
            <br/><br/>
            <ShowOptions></ShowOptions>
            <button class="btn btn-success" @click="saveChallenge()">Goym</button>
        </div>
        <div v-else class="border challenge">
            <h5 class="challengeName">{{ challengeStore.activeChallenge.Name }}</h5>
            <h2 class="challengeText">{{ challengeStore.activeChallenge.Text }}</h2>
            <h5 class="challengeQuestion">{{ challengeStore.activeChallenge.Question }}</h5>
            <br/><br/>
            <ShowOptions></ShowOptions>
        </div>
    </div>
</template>

<script setup>
    import ShowOptions from './ShowOptions.vue';
    import { useChallengeStore } from "@/stores/challenge";

    const challengeStore = useChallengeStore();

    const saveChallenge = () => {
        challengeStore.saveChallenge();
        challengeStore.editMode = false;
    };
</script>
<style scoped>
    .challenge{
        width: 100%;
        margin: 0 auto;
        padding: 15px;
    }

    .challengeName {
        text-align: left;
    }

    .challengeText{
        text-align: center;
        margin-top: 45px;
        margin-bottom: 5px;
    }

    .challengeQuestion{
        text-align: right;
    }
</style>