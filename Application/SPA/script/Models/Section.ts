import Answer from "./Answer";
import { Question } from "./Question";

export default interface Section {
    SectionID: number;
    Text: string;
    Questions: Question[];
    Answers: Answer[];
    Order: number;
}