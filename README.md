# Unity3Dpractice
unity 6.3 LTS ver 3D practice


## 상태 머신

1. 상태 보관 : 컨트롤러가 상태 보관


2. 상태 교체 : 상태 머신이 상태 교체
    이전 상태 Exit
    현재 상태 교체
    현재 상태 Enter

3. 현재 상태의 행동 수행 : 상태 머신이 현재 current의 할 일 수행

---

## TODO

### 슬라임으로 상태머신 확장하기
기존 State Base를 SlimeIdle, SlimeAttack 등 상태가 상속하고

SlimeController는 IStateEvenet를 상속하여 상태변화를 감지하고

### 상태 머신 없이 그래프로 간선 처리해서 구현하기 - Behaviour Tree

상태를 노드화해서 연결하는 방식 고려 → Behaviour Tree

둘 중에 선택해야하는 경우도 존재한다. 더 상황에 최적인 방법을 사용하자.
왜 최적의 수인지에 대한 판단 근거는 본인이 설명할 수 있어야 한다.
