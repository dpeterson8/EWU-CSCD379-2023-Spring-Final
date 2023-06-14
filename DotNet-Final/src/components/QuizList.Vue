<template>
  <v-card
    class="mx-auto mt-30"
    max-width="600"
  >
  <v-list density="compact">
      <v-list-subheader>Quiz List!</v-list-subheader>

      <v-list-item
        v-for="(item, i) in quiz"
        :key="i"
        :value="item"
        color="primary"
        @click="activeQuiz = item.id"
      >

        <QuizCard v-if="activeQuiz == item.id" :questionId="item.id"></QuizCard>
        <v-list-item-title v-text="item.name"></v-list-item-title>
      </v-list-item>
    </v-list>
  </v-card>
</template>

<script lang="ts" setup>
import Axios from 'axios'
import { ref } from 'vue'
import { TestQuiz } from '../scripts/testQuiz'
import QuizCard from '../components/QuizCard.vue'

const activeQuiz = ref(0)
const quiz = ref<TestQuiz[]>([])
const quizId = ref(1)

//Quiz/GetQuestions?Id=1
Axios.get('/Quiz/GetQuizList').then((result) => {
  console.log(result.data)
  quiz.value = result.data as TestQuiz[]
  console.log(quiz.value[0])
  console.log(result.data)
})

function selectQuestion(index: number) {
  quizId.value = index

}


</script>