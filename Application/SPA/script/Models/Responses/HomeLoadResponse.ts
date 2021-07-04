import { AnswerSet } from "../../Store/AnswerStore";
import Section from "../Section";

export default interface HomeLoadResponse {
    SessionAnswerSets: AnswerSet[]
    Sections: Section[];
}