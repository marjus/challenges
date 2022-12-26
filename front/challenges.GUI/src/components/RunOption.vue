<template >
    <div @click="optionClicked(option)" class="alert alert-dismissible border option"  >
                    <h6>
                        {{ option.Content }}
                    </h6>
                </div>
</template>

<script setup>

    const isSelected = false;
    const isCorrect = false;
    const option = {};

</script>

<style scoped>
    
</style>