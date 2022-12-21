<template>
    <h1>Uppgávur</h1>
    <div class="row">
        <table class="table table-striped">
            <thead>
                <tr>
                    <th>Nummar</th>
                    <th>Navn</th>
                    <th>Spurningur</th>
                    <th>Tekstur</th>
                </tr>
            </thead>
            <tbody v-for="(challenge, index) in challengeStore.challengeData.Challenges" :key="index">
                <tr>
                    <td>
                        {{ challenge.OrderInSequence }}
                    </td>
                    <td>
                        {{ challenge.Name }}
                    </td>
                    <td>
                        {{ challenge.Question }}
                    </td>
                    <td>
                        {{ challenge.Text }}
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script setup>
    import { ref, onMounted, computed } from "vue";
    import { useChallengeStore } from "@/stores/challenge";

    const challengeStore = useChallengeStore();

    onMounted(() => {
        challengeStore.fetchChallenges();
    });

</script>