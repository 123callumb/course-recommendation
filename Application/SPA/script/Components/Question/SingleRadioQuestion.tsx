import { Radio, RadioGroup, Stack } from "@chakra-ui/react";
import React from "react";
import { connect } from "react-redux";
import Answer from "../../Models/Answer";
import { AnswerSet } from "../../Store/AnswerStore";
import { AppState } from "../../Store/Reducer";
import { SetAnswerSet } from "../../Store/AnswerStore";

interface SingleRadioComp_Props {
    groupID: number;
    sectionID: number;
    answers: Answer[];
    answerSet?: AnswerSet;
    SetAnswerSet?: typeof SetAnswerSet;
}

class SingleRadioQuestion_Comp extends React.Component<SingleRadioComp_Props> {
    constructor(props: SingleRadioComp_Props) {
        super(props);
    }

    render() {
        return <RadioGroup value={this.props.answerSet?.AnswerID.toString()} onChange={(nextVal: string) => this.props.SetAnswerSet(this.props.groupID, this.props.sectionID, parseInt(nextVal))}>
            <Stack spacing="3" mt="3">
                {this.props.answers.map((e, i) =>
                    <Radio size="md" key={i} value={e.AnswerID.toString()}>
                        {e.Text}
                    </Radio>)}
            </Stack>
        </RadioGroup>;
    }
}

export default connect((state: AppState, props: SingleRadioComp_Props): SingleRadioComp_Props => ({
    ...props
}), {
    SetAnswerSet
})(SingleRadioQuestion_Comp);