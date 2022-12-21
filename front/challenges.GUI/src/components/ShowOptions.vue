<template>
    <div class="options">
        <div class="row">
            <div class="col-md-6">
                {{ options[0]. }}
            </div>
        </div>
    </div>
</template>

<script setup>
  //  import { useChallengeStore } from "@/stores/challenge";

    const props = defineProps({       
        options: []
    })
</script>

<style scoped>
    
</style>