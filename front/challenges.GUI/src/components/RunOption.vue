<template >
    <div @click="optionClicked(option)" class="alert alert-dismissible border option" :class="{ 'alert-success': isSelected && props.option.IsCorrect,
      'alert-danger': isSelected && !props.option.IsCorrect}" >
        <h6>
            {{ props.option.Content }}
        </h6>
    </div>
</template>

<script setup>
    import {ref} from 'vue'
    const props = defineProps({
        option: Object
    })

    var isSelected = ref(false);

    const optionClicked = (option) => { 
        isSelected.value = true;
    }; 
</script>

<style scoped>
    
</style>