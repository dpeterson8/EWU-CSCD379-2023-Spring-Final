import type { Question } from './question'

export class Quiz {
  quizTitle: string | null
  questions = Array<Question>()
  timePerQuestion = 45
  timeTaken = 0
  curQuestionIndex = 0

  constructor(questions?: Array<Question> | null, title?: string | null) {
    if (title) this.quizTitle = title
    else this.quizTitle = null
    questions?.forEach((value) => {
      this.questions.push(value)
    })
  }

  public getQuestion(index: number = 0) {
    if (index) return this.questions[index]
    else return this.curQuestion
  }

  get title() {
    return this.quizTitle
  }

  get curQuestion() {
    return this.questions[this.curQuestionIndex]
  }

  get nextQuestion() {
    this.curQuestionIndex++
    return this.questions[this.curQuestionIndex]
  }

  get prevQuestion() {
    if (this.curQuestionIndex <= 0) {
      return this.questions[0]
    }
    this.curQuestionIndex--
    return this.questions[this.curQuestionIndex]
  }

  get questionCount() {
    return this.questions.length
  }
}
