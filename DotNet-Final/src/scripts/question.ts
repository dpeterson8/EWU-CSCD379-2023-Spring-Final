import { Answer } from './answer'

export enum LetterStatus {
  NotGuessed = 0,
  Correct,
  Incorrect
}

export class Question {
  questionNumber: number | null
  question: string | null
  correctAnswer: string | null
  answers = new Array<string>()
  status: LetterStatus = LetterStatus.NotGuessed

  constructor(
    question?: string | null,
    questionNum?: number | null,
    corAns?: string | null,
    incAnsArr?: Array<string> | null
  ) {
    if (question && corAns && incAnsArr && questionNum) {
      this.questionNumber = questionNum
      this.question = question
      this.correctAnswer = corAns
      incAnsArr.forEach((value) => {
        this.answers.push(value)
      })
    } else {
      this.questionNumber = 0
      this.question = 'test'
      this.correctAnswer = 'test'
    }
  }

  get questionId() {
    return this.questionNumber
  }

  get curQuestion() {
    return this.question
  }

  get corAnswer() {
    return this.correctAnswer
  }

  get allAnswer() {
    return this.answers
  }
}
