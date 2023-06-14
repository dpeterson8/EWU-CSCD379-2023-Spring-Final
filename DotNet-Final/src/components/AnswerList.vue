<template>
        <v-card-actions
        class="d-flex flex-column align-start"
        v-for="answer in answers"
      >
        <v-checkbox :disabled="isActive" :label="answer.answer" @click="checkLetter(answer.answer)"></v-checkbox>
      </v-card-actions>
</template>

<script lang="ts" setup>
import Axios from 'axios'
import { reactive, ref } from 'vue'
import type { TestAnswer } from '../scripts/testAnswer'

const props = defineProps<{
  questionId: number
}>()

const answers = ref<TestAnswer[]>([])
const isActive = ref(false)

Axios.get(`Quiz/GetAnswers?Id=${props.questionId}`).then((result) => {
  console.log(result.data)
  answers.value = result.data as TestAnswer[]

})

function testMethod(value: string) {
    console.log(value)
}

const emit = defineEmits<{
  (e: 'checkLetter', value: string): void
}>()

function checkLetter(letter: string) {
  isActive.value = true
  emit('checkLetter', letter)
}

</script>
