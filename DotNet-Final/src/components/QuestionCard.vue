<template>
  <div class="d=flex">
    <v-card width="80%" v-for="(item, i) in questions">
      <v-card-title>Question #{{ item.id }}</v-card-title>
      <v-card-subtitle> {{ item.questionText }} </v-card-subtitle>


      <AnswerList :questionId="item.id" @check-letter="checkGuess"></AnswerList>

    </v-card>
  </div>
</template>

<script lang="ts" setup>
import Axios from 'axios'
import { reactive, ref } from 'vue'
import type { Question } from '../scripts/question'
import { watch } from 'vue'
import type { TestQuestion } from '../scripts/testQuestion'
import AnswerList from '../components/AnswerList.vue'

const props = defineProps<{
  questionId: number
}>()

const questions = ref<TestQuestion[]>([])
const questionCount = ref(0)

Axios.get(`Quiz/GetQuestions?Id=${props.questionId}`).then((result) => {
  console.log(result.data)
  questions.value = result.data as TestQuestion[]
  console.log(questions.value[1])
})


function checkGuess(letter: string) {
  questionCount.value++
  console.log("Question: " + letter)
  if (letter == questions.value[0].correctAnswer) {
    console.log("Winner")
    submitQuestion(true,false)
  }

  if(questionCount.value == questions.value.length) {
    submitQuestion(false,true)
  }
}

const emit = defineEmits<{
  (e: 'submitQuestion', value: boolean, active: boolean): void
}>()

function submitQuestion(letter: boolean, active: boolean) {
  emit('submitQuestion', letter, active)
}

</script>
