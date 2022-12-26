<template>

    <div class="row">      
        <div class="col">
            <div class="border challenge">
                <h3 class="challengeName">{{ challengeStore.activeChallenge.Name }}</h3>
                <h5 class="challengeText">{{ challengeStore.activeChallenge.Text }}</h5>
                <h5 class="challengeQuestion">{{ challengeStore.activeChallenge.Question }}</h5>
                <br/><br/>
                <RunOptions></RunOptions>
            </div>
            <div class="border control">
                <button @click="nextChallenge()" class="btn btn-success"><i class="bi bi-caret-right"></i> Næsta</button>
            </div>
        </div>
    </div>
</template>

<script setup>
    import { ref, onMounted, computed } from "vue";
    import { useChallengeStore } from "@/stores/challenge";
    import RunOptions from "./RunOptions.vue";

    const challengeStore = useChallengeStore();

    const displayChallenge = (challenge) => {
        challengeStore.setActive(challenge);
        challengeStore.editMode = false;
    };

    const nextChallenge = () => {
        challengeStore.loadNext();
    };

    onMounted(() => {
        challengeStore.fetchChallenges();
        challengeStore.loadRandom();
        challengeStore.runMode = true;
    });

</script>

<style scoped>
    .challenge{
        width: 100%;
        margin: 0 auto;
        padding: 15px;
    }
    .control{
        width: 100%;
        margin-top: 10px;
        padding: 15px;
        text-align: right;
    }
    .challengeName {
        text-align: left;
    }

    .challengeQuestion{
        text-align: right;
    }
</style>